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
    public class contactInfoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public contactInfoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: contactInfo
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContactInfo.ToListAsync());
        }

        // GET: contactInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactInfoModel = await _context.ContactInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactInfoModel == null)
            {
                return NotFound();
            }

            return View(contactInfoModel);
        }

        // GET: contactInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: contactInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PhoneNumber,Adress,Postkod,City,Email")] ContactInfoModel contactInfoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactInfoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactInfoModel);
        }

        // GET: contactInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactInfoModel = await _context.ContactInfo.FindAsync(id);
            if (contactInfoModel == null)
            {
                return NotFound();
            }
            return View(contactInfoModel);
        }

        // POST: contactInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PhoneNumber,Adress,Postkod,City,Email")] ContactInfoModel contactInfoModel)
        {
            if (id != contactInfoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactInfoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactInfoModelExists(contactInfoModel.Id))
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
            return View(contactInfoModel);
        }

        // GET: contactInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactInfoModel = await _context.ContactInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactInfoModel == null)
            {
                return NotFound();
            }

            return View(contactInfoModel);
        }

        // POST: contactInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactInfoModel = await _context.ContactInfo.FindAsync(id);
            if (contactInfoModel != null)
            {
                _context.ContactInfo.Remove(contactInfoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactInfoModelExists(int id)
        {
            return _context.ContactInfo.Any(e => e.Id == id);
        }
    }
}
