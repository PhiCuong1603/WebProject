using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Data;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AuthorController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Author.ToList());
        }

        //GET Create Action Method
        public IActionResult Create()
        {
            return View();
        }
        // Post create action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Author author)
        {
            if (ModelState.IsValid)
            {
                _db.Add(author);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        //GET Edit Action Method
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var author = await _db.Author.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }
        // Post Edit action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Author author)
        {
            if (id != author.AuthorID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Update(author);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }
        //GET Details Action Method
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _db.Author.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }


        //GET Delete Action Method
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _db.Author.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        //POST Delete action Method
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var author = await _db.Author.FindAsync(id);
            _db.Author.Remove(author);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}