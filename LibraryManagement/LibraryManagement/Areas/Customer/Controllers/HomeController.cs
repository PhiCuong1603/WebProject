using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LibraryManagement.Models;
using LibraryManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;


        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var BookList = await _db.Book.Include(m => m.Author).Include(m => m.Category).ToListAsync();
            return View(BookList);
        }

        public async Task<IActionResult> Details(int id)
        {
            var book = await _db.Book.Include(m => m.Author).Include(m => m.Category).Where(m => m.BookID == id).FirstOrDefaultAsync();

            return View(book);
        }

        //[HttpPost, ActionName("Details")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Details(int id)
        //{
           
        //    return RedirectToAction("Index", "Home", new { area = "Customer" });

        //}



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
