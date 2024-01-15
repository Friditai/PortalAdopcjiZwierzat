using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalAdopcjiZwierzat.Data;
using PortalAdopcjiZwierzat.Models.Zwierzeta;

namespace PortalAdopcjiZwierzat.Controllers
{
    public class ZwierzeController : Controller
    {
        private readonly PortalAdopcjiZwierzatContext _context;

        public ZwierzeController(PortalAdopcjiZwierzatContext context)
        {
            _context = context;
        }

        // GET: Zwierze
        public async Task<IActionResult> Index(string searchString)
        {

              if (_context.Zwierze == null)
            {
                return Problem("Entity set 'PortalAdopcjiZwierzatContext.Zwierze'  is null.");
               
            }
            var zwierzeta = from z in _context.Zwierze
                            select z;

            if (!String.IsNullOrEmpty(searchString))
            {
                zwierzeta = zwierzeta.Where(s => s.Nazwa!.Contains(searchString) || s.Imie!.Contains(searchString)
                || s.Umaszczenie!.Contains(searchString) || s.Opis!.Contains(searchString));
            }


            return View(await zwierzeta.ToListAsync());
                             
              
        }

        // GET: Zwierze/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Zwierze == null)
            {
                return NotFound();
            }

            var zwierze = await _context.Zwierze
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zwierze == null)
            {
                return NotFound();
            }

            return View(zwierze);
        }

        // GET: Zwierze/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zwierze/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Adoptowany,Imie,Nazwa,Plec,Rasa,Umaszczenie,Siersc,Wiek,Opis,ZdjecieUrl")] Zwierze zwierze)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zwierze);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zwierze);
        }

        // GET: Zwierze/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Zwierze == null)
            {
                return NotFound();
            }

            var zwierze = await _context.Zwierze.FindAsync(id);
            if (zwierze == null)
            {
                return NotFound();
            }
            return View(zwierze);
        }

        // POST: Zwierze/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Adoptowany,Imie,Nazwa,Plec,Rasa,Umaszczenie,Siersc,Wiek,Opis,ZdjecieUrl")] Zwierze zwierze)
        {
            if (id != zwierze.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zwierze);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZwierzeExists(zwierze.Id))
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
            return View(zwierze);
        }

        // GET: Zwierze/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Zwierze == null)
            {
                return NotFound();
            }

            var zwierze = await _context.Zwierze
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zwierze == null)
            {
                return NotFound();
            }

            return View(zwierze);
        }

        // POST: Zwierze/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Zwierze == null)
            {
                return Problem("Entity set 'PortalAdopcjiZwierzatContext.Zwierze'  is null.");
            }
            var zwierze = await _context.Zwierze.FindAsync(id);
            if (zwierze != null)
            {
                _context.Zwierze.Remove(zwierze);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZwierzeExists(int id)
        {
          return (_context.Zwierze?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
