using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ViinitDBMain.Models;

namespace ViinitDBMain.Controllers
{
    public class ViinitController : Controller
    {
        private readonly ViinitDBContext _context = new ViinitDBContext();

        // GET: Viinit
        public async Task<IActionResult> Index()
        {
            var viinitDBContext = _context.Viinits.Include(v => v.Tyyppi);
            return View(await viinitDBContext.ToListAsync());
        }

        // Haku
        public async Task<IActionResult> Haku(string nimi)
        {
            var viinitDBContext = _context.Viinits.Where(viini => viini.Nimi.ToLower().Contains(nimi.ToLower())).
                Include(v => v.Tyyppi);
            return View(await viinitDBContext.ToListAsync());
        }

        // GET: Viinit/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Viinits == null)
            {
                return NotFound();
            }

            var viinit = await _context.Viinits
                .Include(v => v.Tyyppi)
                .FirstOrDefaultAsync(m => m.ViiniId == id);
            if (viinit == null)
            {
                return NotFound();
            }

            return View(viinit);
        }

        // GET: Viinit/Create
        public IActionResult Create()
        {
            ViewData["TyyppiId"] = new SelectList(_context.Viinityypits, "TyyppiId", "Viinityyppi");
            return View();
        }

        // POST: Viinit/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nimi,Vuosi,TyyppiId,Kommentit,Hinta")] Viinit viinit)
        {
            
           
                _context.Add(viinit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["TyyppiId"] = new SelectList(_context.Viinityypits, "TyyppiId", "TyyppiId", viinit.TyyppiId);
            return View(viinit);
        }

        // GET: Viinit/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Viinits == null)
            {
                return NotFound();
            }

            var viinit = await _context.Viinits.FindAsync(id);
            if (viinit == null)
            {
                return NotFound();
            }
            ViewData["TyyppiId"] = new SelectList(_context.Viinityypits, "TyyppiId", "TyyppiId", viinit.TyyppiId);
            return View(viinit);
        }

        // POST: Viinit/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ViiniId,Nimi,Vuosi,TyyppiId,Kommentit,Hinta")] Viinit viinit)
        {
            if (id != viinit.ViiniId)
            {
                return NotFound();
            }

            
     
                try
                {
                    _context.Update(viinit);
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    if (!ViinitExists(viinit.ViiniId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw e;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            ViewData["TyyppiId"] = new SelectList(_context.Viinityypits, "TyyppiId", "TyyppiId", viinit.TyyppiId);
            return View(viinit);
        }

        // GET: Viinit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Viinits == null)
            {
                return NotFound();
            }

            var viinit = await _context.Viinits
                .Include(v => v.Tyyppi)
                .FirstOrDefaultAsync(m => m.ViiniId == id);
            if (viinit == null)
            {
                return NotFound();
            }

            return View(viinit);
        }

        // POST: Viinit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Viinits == null)
            {
                return Problem("Entity set 'ViinitDBContext.Viinits'  is null.");
            }
            var viinit = await _context.Viinits.FindAsync(id);
            if (viinit != null)
            {
                _context.Viinits.Remove(viinit);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ViinitExists(int id)
        {
          return _context.Viinits.Any(e => e.ViiniId == id);
        }
    }
}
