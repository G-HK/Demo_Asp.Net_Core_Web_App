using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HsPXL.Data;
using HsPXL.Models;
using Microsoft.AspNetCore.Authorization;

namespace HsPXL.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class InschrijvingsController : Controller
    {
        private readonly HsPXLContext _context;

        public InschrijvingsController(HsPXLContext context)
        {
            _context = context;
        }

        // GET: Inschrijvings
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var hsPXLContext = _context.Inschrijving.Include(i => i.Cursus).Include(i => i.Student);

            //ViewData["Students"] = _context.Student.AsNoTracking().ToList();
            //ViewData["Cursus"] = _context.Cursus.AsNoTracking().ToList();

            return View(await hsPXLContext.ToListAsync());
        }

        // GET: Inschrijvings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inschrijving = await _context.Inschrijving
                .Include(i => i.Cursus)
                .Include(i => i.Student)
                .FirstOrDefaultAsync(m => m.InschrijvingID == id);
            if (inschrijving == null)
            {
                return NotFound();
            }

            return View(inschrijving);
        }

        // GET: Inschrijvings/Create
        public IActionResult Create()
        {
            ViewData["CursusID"] = new SelectList(_context.Cursus, "CursusID", "CursusName");
            CreateViewDataStudentID();


            return View();
        }



        public void CreateViewDataStudentID()
        {
            var Name = _context.Student.Select(s => new
            {
                StudentID = s.StudentID,
                Naam = string.Format("{0} {1}", s.Naam, s.Voornaam)
            });

            ViewData["StudentID"] = new SelectList(Name, "StudentID", "Naam");
        }

        // POST: Inschrijvings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InschrijvingID,StudentID,CursusID")] Inschrijving inschrijving)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inschrijving);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursusID"] = new SelectList(_context.Cursus, "CursusID", "CursusName", inschrijving.CursusID);
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "Naam", inschrijving.StudentID);
            return View(inschrijving);
        }

        // GET: Inschrijvings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inschrijving = await _context.Inschrijving.FindAsync(id);
            if (inschrijving == null)
            {
                return NotFound();
            }
            ViewData["CursusID"] = new SelectList(_context.Cursus, "CursusID", "CursusName", inschrijving.CursusID);
            // ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "Naam", inschrijving.StudentID);
            CreateViewDataStudentID();

            return View(inschrijving);
        }

        // POST: Inschrijvings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InschrijvingID,StudentID,CursusID")] Inschrijving inschrijving)
        {
            if (id != inschrijving.InschrijvingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inschrijving);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InschrijvingExists(inschrijving.InschrijvingID))
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
            ViewData["CursusID"] = new SelectList(_context.Cursus, "CursusID", "CursusName", inschrijving.CursusID);
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "Naam", inschrijving.StudentID);
            return View(inschrijving);
        }

        // GET: Inschrijvings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inschrijving = await _context.Inschrijving
                .Include(i => i.Cursus)
                .Include(i => i.Student)
                .FirstOrDefaultAsync(m => m.InschrijvingID == id);
            if (inschrijving == null)
            {
                return NotFound();
            }

            return View(inschrijving);
        }

        // POST: Inschrijvings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inschrijving = await _context.Inschrijving.FindAsync(id);
            _context.Inschrijving.Remove(inschrijving);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InschrijvingExists(int id)
        {
            return _context.Inschrijving.Any(e => e.InschrijvingID == id);
        }
    }
}
