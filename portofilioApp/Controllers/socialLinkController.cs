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
    public class socialLinkController : Controller
    {
        private readonly ApplicationDbContext _context;

        public socialLinkController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: socialLink
        public async Task<IActionResult> Index()
        {
            return View(await _context.SocialLinks.ToListAsync());
        }

        // GET: socialLink/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialLinkModel = await _context.SocialLinks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socialLinkModel == null)
            {
                return NotFound();
            }

            return View(socialLinkModel);
        }

        // GET: socialLink/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: socialLink/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Platform,Url,CreatedAt")] SocialLinkModel socialLinkModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(socialLinkModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(socialLinkModel);
        }

        // GET: socialLink/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialLinkModel = await _context.SocialLinks.FindAsync(id);
            if (socialLinkModel == null)
            {
                return NotFound();
            }
            return View(socialLinkModel);
        }

        // POST: socialLink/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Platform,Url,CreatedAt")] SocialLinkModel socialLinkModel)
        {
            if (id != socialLinkModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(socialLinkModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocialLinkModelExists(socialLinkModel.Id))
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
            return View(socialLinkModel);
        }

        // GET: socialLink/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialLinkModel = await _context.SocialLinks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socialLinkModel == null)
            {
                return NotFound();
            }

            return View(socialLinkModel);
        }

        // POST: socialLink/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var socialLinkModel = await _context.SocialLinks.FindAsync(id);
            if (socialLinkModel != null)
            {
                _context.SocialLinks.Remove(socialLinkModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SocialLinkModelExists(int id)
        {
            return _context.SocialLinks.Any(e => e.Id == id);
        }
    }
}
