using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_PAW_043_C.Models;

namespace UCP1_PAW_043_C.Controllers
{
    public class LaporansController : Controller
    {
        private readonly UCPCatatanContext _context;

        public LaporansController(UCPCatatanContext context)
        {
            _context = context;
        }

        // GET: Laporans
        public async Task<IActionResult> Index()
        {
            var uCPCatatanContext = _context.Laporan.Include(l => l.IdAdminNavigation).Include(l => l.IdCatNavigation);
            return View(await uCPCatatanContext.ToListAsync());
        }

        // GET: Laporans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laporan = await _context.Laporan
                .Include(l => l.IdAdminNavigation)
                .Include(l => l.IdCatNavigation)
                .FirstOrDefaultAsync(m => m.IdLaporan == id);
            if (laporan == null)
            {
                return NotFound();
            }

            return View(laporan);
        }

        // GET: Laporans/Create
        public IActionResult Create()
        {
            ViewData["IdAdmin"] = new SelectList(_context.Admin, "IdAdmin", "IdAdmin");
            ViewData["IdCat"] = new SelectList(_context.Catatan, "IdCat", "IdCat");
            return View();
        }

        // POST: Laporans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLaporan,IdAdmin,IdCat,TotalPem,TotalPen")] Laporan laporan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(laporan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAdmin"] = new SelectList(_context.Admin, "IdAdmin", "IdAdmin", laporan.IdAdmin);
            ViewData["IdCat"] = new SelectList(_context.Catatan, "IdCat", "IdCat", laporan.IdCat);
            return View(laporan);
        }

        // GET: Laporans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laporan = await _context.Laporan.FindAsync(id);
            if (laporan == null)
            {
                return NotFound();
            }
            ViewData["IdAdmin"] = new SelectList(_context.Admin, "IdAdmin", "IdAdmin", laporan.IdAdmin);
            ViewData["IdCat"] = new SelectList(_context.Catatan, "IdCat", "IdCat", laporan.IdCat);
            return View(laporan);
        }

        // POST: Laporans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLaporan,IdAdmin,IdCat,TotalPem,TotalPen")] Laporan laporan)
        {
            if (id != laporan.IdLaporan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(laporan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaporanExists(laporan.IdLaporan))
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
            ViewData["IdAdmin"] = new SelectList(_context.Admin, "IdAdmin", "IdAdmin", laporan.IdAdmin);
            ViewData["IdCat"] = new SelectList(_context.Catatan, "IdCat", "IdCat", laporan.IdCat);
            return View(laporan);
        }

        // GET: Laporans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laporan = await _context.Laporan
                .Include(l => l.IdAdminNavigation)
                .Include(l => l.IdCatNavigation)
                .FirstOrDefaultAsync(m => m.IdLaporan == id);
            if (laporan == null)
            {
                return NotFound();
            }

            return View(laporan);
        }

        // POST: Laporans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var laporan = await _context.Laporan.FindAsync(id);
            _context.Laporan.Remove(laporan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaporanExists(int id)
        {
            return _context.Laporan.Any(e => e.IdLaporan == id);
        }
    }
}
