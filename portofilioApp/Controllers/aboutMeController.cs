using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortfolioApp.Models;
using portofilioApp.Data;

namespace portofilioApp.Controllers
{
    [Authorize]
    public class aboutMeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public aboutMeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: aboutMe
        public async Task<IActionResult> Index()
        {
            return View(await _context.About.ToListAsync());
        }

        // GET: aboutMe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutMeModel = await _context.About
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aboutMeModel == null)
            {
                return NotFound();
            }

            return View(aboutMeModel);
        }

        // GET: aboutMe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: aboutMe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,About,Url")] AboutMeModel aboutMeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aboutMeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aboutMeModel);
        }

        // GET: aboutMe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutMeModel = await _context.About.FindAsync(id);
            if (aboutMeModel == null)
            {
                return NotFound();
            }
            return View(aboutMeModel);
        }

        // POST: aboutMe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,About,Url")] AboutMeModel aboutMeModel)
        {
            if (id != aboutMeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aboutMeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutMeModelExists(aboutMeModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(aboutMeModel);
        }

        // GET: aboutMe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutMeModel = await _context.About
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aboutMeModel == null)
            {
                return NotFound();
            }

            return View(aboutMeModel);
        }

        // POST: aboutMe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aboutMeModel = await _context.About.FindAsync(id);
            if (aboutMeModel != null)
            {
                _context.About.Remove(aboutMeModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AboutMeModelExists(int id)
        {
            return _context.About.Any(e => e.Id == id);
        }
    }
}
