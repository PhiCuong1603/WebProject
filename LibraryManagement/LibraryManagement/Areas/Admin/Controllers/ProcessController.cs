using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Data;
using LibraryManagement.Models;
using LibraryManagement.Models.ViewModel;
using LibraryManagement.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.AdminEndUser + "," + SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class ProcessController : Controller
    {
        private readonly ApplicationDbContext _db;
        private int PageSize = 3;

        public ProcessController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index(int ProcessPage = 1, string searchName = null, string searchEmail = null, string searchPhone = null, string searchDate = null)
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            ProcessViewModel ProcessVM = new ProcessViewModel()
            {
                Processes = new List<Models.Process>()
            };

            StringBuilder param = new StringBuilder();

            param.Append("/Admin/Process?ProcessPage=:");
            param.Append("&searchName=");
            if (searchName != null)
            {
                param.Append(searchName);
            }
            param.Append("&searchEmail=");
            if (searchEmail != null)
            {
                param.Append(searchEmail);
            }
            param.Append("&searchPhone=");
            if (searchPhone != null)
            {
                param.Append(searchPhone);
            }
            param.Append("&searchDate=");
            if (searchDate != null)
            {
                param.Append(searchDate);
            }

            ProcessVM.Processes = _db.Process.Include(a => a.Librarian).ToList();
            if (User.IsInRole(SD.AdminEndUser))
            {
                ProcessVM.Processes = ProcessVM.Processes.Where(a => a.LibrarianID == claim.Value).ToList();
            }


            if (searchName != null)
            {
                ProcessVM.Processes = ProcessVM.Processes.Where(a => a.ReaderName.ToLower().Contains(searchName.ToLower())).ToList();
            }
            if (searchEmail != null)
            {
                ProcessVM.Processes = ProcessVM.Processes.Where(a => a.ReaderEmail.ToLower().Contains(searchEmail.ToLower())).ToList();
            }
            if (searchPhone != null)
            {
                ProcessVM.Processes = ProcessVM.Processes.Where(a => a.ReaderPhoneNumber.ToLower().Contains(searchPhone.ToLower())).ToList();
            }
            if (searchDate != null)
            {
                try
                {
                    DateTime appDate = Convert.ToDateTime(searchDate);
                    ProcessVM.Processes = ProcessVM.Processes.Where(a => a.BorrowedDate.ToShortDateString().Equals(appDate.ToShortDateString())).ToList();
                }
                catch (Exception ex)
                {

                }

            }

            var count = ProcessVM.Processes.Count;

            ProcessVM.Processes = ProcessVM.Processes.OrderBy(p => p.BorrowedDate)
                .Skip((ProcessPage - 1) * PageSize)
                .Take(PageSize).ToList();


            ProcessVM.PagingInfo = new PagingInfo
            {
                CurrentPage = ProcessPage,
                ItemsPerPage = PageSize,
                TotalItems = count,
                urlParam = param.ToString()
            };


            return View(ProcessVM);
        }

        //GET Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var BooksList = /*(IEnumerable<Book>)*/(from b in _db.Book join a in _db.Borrowed
                                                      on b.BookID equals a.BookID
                                                      where a.ProcessID == id  
                                                      select b).Include("Author").Include("Category");

            ProcessDetailsViewModel objProDetailsVM = new ProcessDetailsViewModel()
            {
                Librarian = _db.ApplicationUser.ToList(),
                Process = _db.Process.Include(a => a.Librarian).Where(a => a.ProcessID == id).FirstOrDefault(),
                Books = BooksList.ToList()
            };

            return View(objProDetailsVM);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProcessDetailsViewModel objProDetailsVM)
        {
            if (ModelState.IsValid)
            {
                objProDetailsVM.Process.BorrowedDate = objProDetailsVM.Process.BorrowedDate
                                    .AddHours(objProDetailsVM.Process.BorrowedTime.Hour)
                                    .AddMinutes(objProDetailsVM.Process.BorrowedTime.Minute);

                var ProcessFromDb = _db.Process.Where(a => a.ProcessID == objProDetailsVM.Process.ProcessID).FirstOrDefault();

                ProcessFromDb.ReaderEmail = objProDetailsVM.Process.ReaderName;
                ProcessFromDb.ReaderEmail = objProDetailsVM.Process.ReaderEmail;
                ProcessFromDb.ReaderPhoneNumber = objProDetailsVM.Process.ReaderPhoneNumber;
                ProcessFromDb.BorrowedDate = objProDetailsVM.Process.BorrowedDate;
                ProcessFromDb.Complete = objProDetailsVM.Process.Complete;
                if (User.IsInRole(SD.SuperAdminEndUser))
                {
                    ProcessFromDb.LibrarianID = objProDetailsVM.Process.LibrarianID;
                }
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));


            }

            return View(objProDetailsVM);
        }

        //GET Detials
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var BooksList = (IEnumerable<Book>)(from b in _db.Book
                                                join a in _db.Borrowed
                                                on b.BookID equals a.BookID
                                                where a.BorrowedID == id
                                                select b).Include("Author").Include("Category");

            ProcessDetailsViewModel objProDetailsVM = new ProcessDetailsViewModel()
            {
                Process = _db.Process.Include(a => a.Librarian).Where(a => a.ProcessID == id).FirstOrDefault(),
                Librarian = _db.ApplicationUser.ToList(),
                Books = BooksList.ToList()
            };

            return View(objProDetailsVM);

        }


        //GET Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var BooksList = (IEnumerable<Book>)(from b in _db.Book
                                                join a in _db.Borrowed
                                                on b.BookID equals a.BookID
                                                where a.BorrowedID == id
                                                select b).Include("Author").Include("Category");

            ProcessDetailsViewModel objProDetailsVM = new ProcessDetailsViewModel()
            {
                Process = _db.Process.Include(a => a.Librarian).Where(a => a.ProcessID == id).FirstOrDefault(),
                Librarian = _db.ApplicationUser.ToList(),
                Books = BooksList.ToList()
            };

            return View(objProDetailsVM);

        }


        //POST Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var process = await _db.Process.FindAsync(id);
            _db.Process.Remove(process);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}