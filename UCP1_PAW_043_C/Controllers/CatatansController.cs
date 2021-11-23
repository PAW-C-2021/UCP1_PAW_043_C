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
    public class CatatansController : Controller
    {
        private readonly UCPCatatanContext _context;

        public CatatansController(UCPCatatanContext context)
        {
            _context = context;
        }

        // GET: Catatans
        public async Task<IActionResult> Index()
        {
            var uCPCatatanContext = _context.Catatan.Include(c => c.IdKategoriNavigation);
            return View(await uCPCatatanContext.ToListAsync());
        }

        // GET: Catatans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catatan = await _context.Catatan
                .Include(c => c.IdKategoriNavigation)
                .FirstOrDefaultAsync(m => m.IdCat == id);
            if (catatan == null)
            {
                return NotFound();
            }

            return View(catatan);
        }

        // GET: Catatans/Create
        public IActionResult Create()
        {
            ViewData["IdKategori"] = new SelectList(_context.KategoriCatatan, "IdKategori", "IdKategori");
            return View();
        }

        // POST: Catatans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCat,Tanggal,IdKategori,HargaCat,KeteranganCat")] Catatan catatan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catatan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKategori"] = new SelectList(_context.KategoriCatatan, "IdKategori", "IdKategori", catatan.IdKategori);
            return View(catatan);
        }

        // GET: Catatans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catatan = await _context.Catatan.FindAsync(id);
            if (catatan == null)
            {
                return NotFound();
            }
            ViewData["IdKategori"] = new SelectList(_context.KategoriCatatan, "IdKategori", "IdKategori", catatan.IdKategori);
            return View(catatan);
        }

        // POST: Catatans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCat,Tanggal,IdKategori,HargaCat,KeteranganCat")] Catatan catatan)
        {
            if (id != catatan.IdCat)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catatan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatatanExists(catatan.IdCat))
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
            ViewData["IdKategori"] = new SelectList(_context.KategoriCatatan, "IdKategori", "IdKategori", catatan.IdKategori);
            return View(catatan);
        }

        // GET: Catatans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catatan = await _context.Catatan
                .Include(c => c.IdKategoriNavigation)
                .FirstOrDefaultAsync(m => m.IdCat == id);
            if (catatan == null)
            {
                return NotFound();
            }

            return View(catatan);
        }

        // POST: Catatans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catatan = await _context.Catatan.FindAsync(id);
            _context.Catatan.Remove(catatan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatatanExists(int id)
        {
            return _context.Catatan.Any(e => e.IdCat == id);
        }
    }
}
