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
    public class experienceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public experienceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: experience
        public async Task<IActionResult> Index()
        {
            return View(await _context.Experiences.ToListAsync());
        }

        // GET: experience/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experienceModel = await _context.Experiences
                .FirstOrDefaultAsync(m => m.Id == id);
            if (experienceModel == null)
            {
                return NotFound();
            }

            return View(experienceModel);
        }

        // GET: experience/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: experience/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Company,Role,Description,StartDate,EndDate,CreatedAt")] ExperienceModel experienceModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(experienceModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(experienceModel);
        }

        // GET: experience/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experienceModel = await _context.Experiences.FindAsync(id);
            if (experienceModel == null)
            {
                return NotFound();
            }
            return View(experienceModel);
        }

        // POST: experience/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Company,Role,Description,StartDate,EndDate,CreatedAt")] ExperienceModel experienceModel)
        {
            if (id != experienceModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(experienceModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExperienceModelExists(experienceModel.Id))
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
            return View(experienceModel);
        }

        // GET: experience/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experienceModel = await _context.Experiences
                .FirstOrDefaultAsync(m => m.Id == id);
            if (experienceModel == null)
            {
                return NotFound();
            }

            return View(experienceModel);
        }

        // POST: experience/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var experienceModel = await _context.Experiences.FindAsync(id);
            if (experienceModel != null)
            {
                _context.Experiences.Remove(experienceModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExperienceModelExists(int id)
        {
            return _context.Experiences.Any(e => e.Id == id);
        }
    }
}
