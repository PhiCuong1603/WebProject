using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Data;
using LibraryManagement.Models;
using LibraryManagement.Models.ViewModel;
using LibraryManagement.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvirorment;

        [BindProperty]
        public BookViewModel BookVM { get; set; }

        public BookController(ApplicationDbContext db, IWebHostEnvironment webhostingEnvironment)
        {
            _db = db;
            _webHostEnvirorment = webhostingEnvironment;
            BookVM = new BookViewModel()
            {
                Authors = _db.Author.ToList(),
                Categories = _db.Category.ToList(),                
                Books = new Models.Book()
            };
        }
        public async Task<IActionResult> Index()
        {
            var books = _db.Book.Include(m => m.Author).Include(m => m.Category);
            return View(await books.ToListAsync());
        }

        //Get : Book Create
        public IActionResult Create()
        {
            return View(BookVM);
        }

        //Post : Book Create
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost()
        {
            if (!ModelState.IsValid)
            {
                return View(BookVM);
            }
            _db.Book.Add(BookVM.Books);
            await _db.SaveChangesAsync();

            //Image being saved

            string webRootPath = _webHostEnvirorment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var BookFromDb = _db.Book.Find(BookVM.Books.BookID);

            if (files.Count != 0)
            {
                //Image has been uploaded
                var uploads = Path.Combine(webRootPath, SD.ImageFolder);
                var extension = Path.GetExtension(files[0].FileName);

                using (var filestream = new FileStream(Path.Combine(uploads, BookVM.Books.BookID + extension), FileMode.Create))
                {
                    files[0].CopyTo(filestream);
                }
                BookFromDb.BookImage = @"\" + SD.ImageFolder + @"\" + BookVM.Books.BookID + extension;
            }
            else
            {
                //when user does not upload image
                var uploads = Path.Combine(webRootPath, SD.ImageFolder + @"\" + SD.DeafaultBookImage);
                System.IO.File.Copy(uploads, webRootPath + @"\" + SD.ImageFolder + @"\" + BookVM.Books.BookID + ".png");
                BookFromDb.BookImage = @"\" + SD.ImageFolder + @"\" + BookVM.Books.BookID + ".png";
            }
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        //GET : Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BookVM.Books = await _db.Book.Include(m => m.Author).Include(m => m.Category).SingleOrDefaultAsync(m => m.BookID == id);

            if (BookVM.Books == null)
            {
                return NotFound();
            }

            return View(BookVM);
        }
         

        //Post : Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _webHostEnvirorment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                var BookFromDb = _db.Book.Where(m => m.BookID == BookVM.Books.BookID).FirstOrDefault();

                if (files.Count > 0 && files[0] != null)
                {
                    //if user uploads a new image
                    var uploads = Path.Combine(webRootPath, SD.ImageFolder);
                    var extension_new = Path.GetExtension(files[0].FileName);
                    var extension_old = Path.GetExtension(BookFromDb.BookImage);

                    if (System.IO.File.Exists(Path.Combine(uploads, BookVM.Books.BookID + extension_old)))
                    {
                        System.IO.File.Delete(Path.Combine(uploads, BookVM.Books.BookID + extension_old));
                    }
                    using (var filestream = new FileStream(Path.Combine(uploads, BookVM.Books.BookID + extension_new), FileMode.Create))
                    {
                        files[0].CopyTo(filestream);
                    }
                    BookVM.Books.BookImage = @"\" + SD.ImageFolder + @"\" + BookVM.Books.BookID + extension_new;
                }

                if (BookVM.Books.BookImage != null)
                {
                    BookFromDb.BookImage = BookVM.Books.BookImage;
                }

                BookFromDb.BookName = BookVM.Books.BookName;                         
                BookFromDb.AuthorID = BookVM.Books.AuthorID;
                BookFromDb.CategoryID = BookVM.Books.CategoryID;
               
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(BookVM);
        }


        //GET : Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BookVM.Books = await _db.Book.Include(m => m.Author).Include(m => m.Category).SingleOrDefaultAsync(m => m.BookID == id);

            if (BookVM.Books == null)
            {
                return NotFound();
            }

            return View(BookVM);
        }

        //GET : Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BookVM.Books = await _db.Book.Include(m => m.Author).Include(m => m.Category).SingleOrDefaultAsync(m => m.BookID == id);

            if (BookVM.Books == null)
            {
                return NotFound();
            }

            return View(BookVM);
        }

        //POST : Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string webRootPath = _webHostEnvirorment.WebRootPath;
            Book book = await _db.Book.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }
            else
            {
                var uploads = Path.Combine(webRootPath, SD.ImageFolder);
                var extension = Path.GetExtension(book.BookImage);

                if (System.IO.File.Exists(Path.Combine(uploads, book.BookID + extension)))
                {
                    System.IO.File.Delete(Path.Combine(uploads, book.BookID + extension));
                }
                _db.Book.Remove(book);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
        }
    }
}