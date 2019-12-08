using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Data;
using LibraryManagement.Models;
using LibraryManagement.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.AdminEndUser + "," + SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class ReaderController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ReaderController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Reader.ToList());
        }

        //GET Create Action Method
        public IActionResult Create()
        {
            return View();
        }

        //POST Create action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reader reader)
        {
            if (ModelState.IsValid)
            {
                _db.Add(reader);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reader);
        }


        //GET Edit Action Method
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reader = await _db.Reader.FindAsync(id);
            if (reader == null)
            {
                return NotFound();
            }

            return View(reader);
        }

        //POST Edit action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Reader reader)
        {
            if (id != reader.ReaderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(reader);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reader);
        }

        //GET Details Action Method
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reader = await _db.Reader.FindAsync(id);
            if (reader == null)
            {
                return NotFound();
            }

            return View(reader);
        }


        //GET Delete Action Method
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reader = await _db.Reader.FindAsync(id);
            if (reader == null)
            {
                return NotFound();
            }

            return View(reader);
        }

        //POST Delete action Method
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reader = await _db.Reader.FindAsync(id);
            _db.Reader.Remove(reader);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}