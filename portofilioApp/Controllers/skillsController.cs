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
    public class skillsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public skillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: skills
        public async Task<IActionResult> Index()
        {
            return View(await _context.Skills.ToListAsync());
        }

        // GET: skills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skillsModel = await _context.Skills
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skillsModel == null)
            {
                return NotFound();
            }

            return View(skillsModel);
        }

        // GET: skills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: skills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Icon,Level,CreatedAt")] SkillsModel skillsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skillsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(skillsModel);
        }

        // GET: skills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skillsModel = await _context.Skills.FindAsync(id);
            if (skillsModel == null)
            {
                return NotFound();
            }
            return View(skillsModel);
        }

        // POST: skills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Icon,Level,CreatedAt")] SkillsModel skillsModel)
        {
            if (id != skillsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skillsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkillsModelExists(skillsModel.Id))
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
            return View(skillsModel);
        }

        // GET: skills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skillsModel = await _context.Skills
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skillsModel == null)
            {
                return NotFound();
            }

            return View(skillsModel);
        }

        // POST: skills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var skillsModel = await _context.Skills.FindAsync(id);
            if (skillsModel != null)
            {
                _context.Skills.Remove(skillsModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkillsModelExists(int id)
        {
            return _context.Skills.Any(e => e.Id == id);
        }
    }
}
