using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Data;
using LibraryManagement.Extensions;
using LibraryManagement.Models;
using LibraryManagement.Models.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class BorrowedCartController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        [BindProperty]
        public BorrowedCartViewModels BorrowedCartVM { get; set; }

        public BorrowedCartController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            this._db = db;
            _webHostEnvironment = webHostEnvironment;
            BorrowedCartVM = new BorrowedCartViewModels()
            {
                Books = new List<Models.Book>()
            };
        }
        public async Task<IActionResult> Index()
        {
            List<int> lstBorrowedCart = HttpContext.Session.Get<List<int>>("ssBorrowedCart");
            if (lstBorrowedCart?.Count > 0)
            {

                foreach (int cartItem in lstBorrowedCart)
                {
                    Book book = _db.Book.Include(p => p.Author).Include(p => p.Category).Where(p => p.BookID == cartItem).FirstOrDefault();

                    BorrowedCartVM.Books.Add(book);
                }
            }
            return View(BorrowedCartVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public IActionResult IndexPost()
        {
            List<int> lstCartItems = HttpContext.Session.Get<List<int>>("ssBorrowedCart");

            BorrowedCartVM.Process.BorrowedDate = BorrowedCartVM.Process.BorrowedDate
                                                            .AddHours(BorrowedCartVM.Process.BorrowedTime.Hour)
                                                            .AddMinutes(BorrowedCartVM.Process.BorrowedTime.Minute);

            Process Process = BorrowedCartVM.Process;
            _db.Process.Add(Process);
            _db.SaveChanges();

            int processID = Process.ProcessID;

            foreach(int bookID in lstCartItems)
            {
                Borrowed BooksSelectedForProcess = new Borrowed()
                {
                    ProcessID = processID,
                    BookID = bookID
                };
                _db.Borrowed.Add(BooksSelectedForProcess);
                
            }
            _db.SaveChanges();
            lstCartItems = new List<int>();
            HttpContext.Session.Set("ssBorrowedCart", lstCartItems);

            return RedirectToAction("ProcessComplete","BorrowedCart", new { Id = processID});

        }

        public IActionResult Remove(int id)
        {
            List<int> lstCartItems = HttpContext.Session.Get<List<int>>("ssBorrowedCart");

            if(lstCartItems.Count>0)
            {
                if(lstCartItems.Contains(id))
                {
                    lstCartItems.Remove(id);
                }
            }

            HttpContext.Session.Set("ssBorrowedCart", lstCartItems);

            return RedirectToAction(nameof(Index));
        }

        //Get

        public IActionResult ProcessComplete(int id)
        {
            BorrowedCartVM.Process = _db.Process.Where(a => a.ProcessID == id).FirstOrDefault();
            List<Borrowed> objBookList = _db.Borrowed.Where(p => p.ProcessID == id).ToList();

            foreach (Borrowed BrwObj in objBookList)
            {
                BorrowedCartVM.Books.Add(_db.Book.Include(p => p.Author).Include(p => p.Category).Where(p => p.BookID == BrwObj.BookID).FirstOrDefault());
            }
            return View(BorrowedCartVM);
        }
    }
}