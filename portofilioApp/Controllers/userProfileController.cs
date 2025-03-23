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
    public class userProfileController : Controller
    {
        private readonly ApplicationDbContext _context;

        public userProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: userProfile
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserProfiles.ToListAsync());
        }

        // GET: userProfile/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProfileModel = await _context.UserProfiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userProfileModel == null)
            {
                return NotFound();
            }

            return View(userProfileModel);
        }

        // GET: userProfile/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: userProfile/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Biog,Image,CreatedAt")] UserProfileModel userProfileModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userProfileModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userProfileModel);
        }

        // GET: userProfile/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProfileModel = await _context.UserProfiles.FindAsync(id);
            if (userProfileModel == null)
            {
                return NotFound();
            }
            return View(userProfileModel);
        }

        // POST: userProfile/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Biog,Image,CreatedAt")] UserProfileModel userProfileModel)
        {
            if (id != userProfileModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userProfileModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserProfileModelExists(userProfileModel.Id))
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
            return View(userProfileModel);
        }

        // GET: userProfile/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProfileModel = await _context.UserProfiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userProfileModel == null)
            {
                return NotFound();
            }

            return View(userProfileModel);
        }

        // POST: userProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userProfileModel = await _context.UserProfiles.FindAsync(id);
            if (userProfileModel != null)
            {
                _context.UserProfiles.Remove(userProfileModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserProfileModelExists(int id)
        {
            return _context.UserProfiles.Any(e => e.Id == id);
        }
    }
}
