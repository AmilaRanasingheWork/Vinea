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
    public class ViinityypitController : Controller
    {
        private readonly ViinitDBContext _context = new ViinitDBContext();


        // GET: Viinityypit
        public async Task<IActionResult> Index()
        {
              return View(await _context.Viinityypits.ToListAsync());
        }

        // GET: Viinityypit/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Viinityypits == null)
            {
                return NotFound();
            }

            var viinityypit = await _context.Viinityypits
                .FirstOrDefaultAsync(m => m.TyyppiId == id);
            if (viinityypit == null)
            {
                return NotFound();
            }

            return View(viinityypit);
        }

        // GET: Viinityypit/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Viinityypit/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TyyppiId,Viinityyppi")] Viinityypit viinityypit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viinityypit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viinityypit);
        }

        // GET: Viinityypit/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Viinityypits == null)
            {
                return NotFound();
            }

            var viinityypit = await _context.Viinityypits.FindAsync(id);
            if (viinityypit == null)
            {
                return NotFound();
            }
            return View(viinityypit);
        }

        // POST: Viinityypit/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TyyppiId,Viinityyppi")] Viinityypit viinityypit)
        {
            if (id != viinityypit.TyyppiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viinityypit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ViinityypitExists(viinityypit.TyyppiId))
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
            return View(viinityypit);
        }

        // GET: Viinityypit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Viinityypits == null)
            {
                return NotFound();
            }

            var viinityypit = await _context.Viinityypits
                .FirstOrDefaultAsync(m => m.TyyppiId == id);
            if (viinityypit == null)
            {
                return NotFound();
            }

            return View(viinityypit);
        }

        // POST: Viinityypit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Viinityypits == null)
            {
                return Problem("Entity set 'ViinitDBContext.Viinityypits'  is null.");
            }
            var viinityypit = await _context.Viinityypits.FindAsync(id);
            if (viinityypit != null)
            {
                _context.Viinityypits.Remove(viinityypit);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ViinityypitExists(int id)
        {
          return _context.Viinityypits.Any(e => e.TyyppiId == id);
        }
    }
}
