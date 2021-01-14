using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HsPXL.Data;
using HsPXL.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using HsPXL.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace HsPXL.Controllers
{
    [Authorize]
    public class HandBoeksController : Controller
    {
        private readonly HsPXLContext _context;
        private readonly IWebHostEnvironment hostingEnvironment;

        public HandBoeksController(HsPXLContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        // GET: HandBoeks
        public async Task<IActionResult> Index()
        {
            return View(await _context.HandBoek.ToListAsync());
        }

        // GET: HandBoeks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var handBoek = await _context.HandBoek
                .FirstOrDefaultAsync(m => m.HandBoekID == id);
            if (handBoek == null)
            {
                return NotFound();
            }

            return View(handBoek);
        }

        // GET: HandBoeks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HandBoeks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HandboekCreateViewModel handboekCreate)
        {
            string uniqueName = null;
            string filePath = null;
            string uploadFolder = null;
            //image
            if (handboekCreate.Afbeelding != null)
            {
               uploadFolder =  Path.Combine(hostingEnvironment.WebRootPath,"images");
               uniqueName = Guid.NewGuid().ToString() + "_" + handboekCreate.Afbeelding.FileName;  // Guid = Global Unique IDentifier // zorgt ervoor dat de bestand een unique naam heeft.
               filePath =  Path.Combine(uploadFolder, uniqueName);
               handboekCreate.Afbeelding.CopyTo(new FileStream(filePath,FileMode.Create));
            }

            HandBoek handBoek = new HandBoek
            {
                Title = handboekCreate.Title,
                KostPrijs = handboekCreate.KostPrijs,
                UitgiftDatum = handboekCreate.UitgiftDatum                
            };
            handBoek.Afbeelding = $"/images/{uniqueName}";
            handBoek.CreationDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Add(handBoek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(handBoek);
        }

        // GET: HandBoeks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var handBoek = await _context.HandBoek.FindAsync(id);
            if (handBoek == null)
            {
                return NotFound();
            }
            return View(handBoek);
        }

        // POST: HandBoeks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HandBoekID,Title,KostPrijs,UitgiftDatum,Afbeelding,CreationDate")] HandBoek handBoek)
        {
            // need to be check for change.
            if (id != handBoek.HandBoekID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(handBoek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HandBoekExists(handBoek.HandBoekID))
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
            return View(handBoek);
        }

        // GET: HandBoeks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var handBoek = await _context.HandBoek.FirstOrDefaultAsync(m => m.HandBoekID == id);
            if (handBoek == null)
            {
                return NotFound();
            }

            return View(handBoek);
        }

        // POST: HandBoeks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var handBoek = await _context.HandBoek.FindAsync(id);
            _context.HandBoek.Remove(handBoek);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HandBoekExists(int id)
        {
            return _context.HandBoek.Any(e => e.HandBoekID == id);
        }
    }
}
