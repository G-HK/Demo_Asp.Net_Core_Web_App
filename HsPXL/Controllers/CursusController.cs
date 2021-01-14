using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HsPXL.Data;
using Microsoft.AspNetCore.Authorization;

namespace HsPXL.Models
{
    [Authorize]
    public class CursusController : Controller
    {
        private readonly HsPXLContext _context;

        public CursusController(HsPXLContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        // GET: Cursus
        public async Task<IActionResult> Index()
        {
            var hsPXLContext = _context.Cursus.Include(c => c.handboek);

            return View(await hsPXLContext.ToListAsync());
        }

        // GET: Cursus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursus = await _context.Cursus
                .Include(c => c.handboek)
                .FirstOrDefaultAsync(m => m.CursusID == id);
            if (cursus == null)
            {
                return NotFound();
            }

            return View(cursus);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Cursus/Create
        public IActionResult Create()
        {
            ViewData["HandboekID"] = new SelectList(_context.Set<HandBoek>(), "HandBoekID", "Title");
            return View();
        }

        // POST: Cursus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CursusID,CursusName,Studiepunten,HandboekID")] Cursus cursus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cursus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HandboekID"] = new SelectList(_context.Set<HandBoek>(), "HandBoekID", "Title", cursus.HandboekID);
            return View(cursus);
        }

        // GET: Cursus/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursus = await _context.Cursus.FindAsync(id);
            if (cursus == null)
            {
                return NotFound();
            }
            ViewData["HandboekID"] = new SelectList(_context.Set<HandBoek>(), "HandBoekID", "Title", cursus.HandboekID);
            return View(cursus);
        }

        // POST: Cursus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("CursusID,CursusName,Studiepunten,HandboekID")] Cursus cursus)
        {
            if (id != cursus.CursusID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cursus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursusExists(cursus.CursusID))
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
            ViewData["HandboekID"] = new SelectList(_context.Set<HandBoek>(), "HandBoekID", "Title", cursus.HandboekID);
            return View(cursus);
        }

        // GET: Cursus/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursus = await _context.Cursus
                .Include(c => c.handboek)
                .FirstOrDefaultAsync(m => m.CursusID == id);
            if (cursus == null)
            {
                return NotFound();
            }

            return View(cursus);
        }

        // POST: Cursus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cursus = await _context.Cursus.FindAsync(id);
            _context.Cursus.Remove(cursus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursusExists(int id)
        {
            return _context.Cursus.Any(e => e.CursusID == id);
        }
    }
}
