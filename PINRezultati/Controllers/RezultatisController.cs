using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PINRezultati.Models;
using PINRezultati.Models.Rezultati;

namespace PINRezultati.Controllers
{
    public class RezultatisController : Controller
    {
        private readonly PINRezultatiContext _context;

        public RezultatisController(PINRezultatiContext context)
        {
            _context = context;
        }

        // GET: Rezultatis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rezultati.ToListAsync());
        }

        // GET: Rezultatis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var rezultati = await _context.Rezultati
                .FirstOrDefaultAsync(m => m.studMb == id);
            if (rezultati == null)
            {
                return Error();
            }

            return View(rezultati);
        }

        // GET: Rezultatis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rezultatis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("studId,studMb,ime,prezime,ocjenaKolokvij,ocjenaProjekt")] Rezultati rezultati)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rezultati);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rezultati);
        }

        // GET: Rezultatis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezultati = await _context.Rezultati.FindAsync(id);
            if (rezultati == null)
            {
                return NotFound();
            }
            return View(rezultati);
        }

        // POST: Rezultatis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("studId,studMb,ime,prezime,ocjenaKolokvij,ocjenaProjekt")] Rezultati rezultati)
        {
            if (id != rezultati.studId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezultati);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezultatiExists(rezultati.studId))
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
            return View(rezultati);
        }

        // GET: Rezultatis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezultati = await _context.Rezultati
                .FirstOrDefaultAsync(m => m.studId == id);
            if (rezultati == null)
            {
                return NotFound();
            }

            return View(rezultati);
        }

        // POST: Rezultatis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezultati = await _context.Rezultati.FindAsync(id);
            _context.Rezultati.Remove(rezultati);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RezultatiExists(int id)
        {
            return _context.Rezultati.Any(e => e.studId == id);
        }
        public IActionResult Error()
        {
            return View("Error");
        }
    }   
}
