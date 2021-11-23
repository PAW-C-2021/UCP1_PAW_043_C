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
    public class KategoriCatatansController : Controller
    {
        private readonly UCPCatatanContext _context;

        public KategoriCatatansController(UCPCatatanContext context)
        {
            _context = context;
        }

        // GET: KategoriCatatans
        public async Task<IActionResult> Index()
        {
            return View(await _context.KategoriCatatan.ToListAsync());
        }

        // GET: KategoriCatatans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategoriCatatan = await _context.KategoriCatatan
                .FirstOrDefaultAsync(m => m.IdKategori == id);
            if (kategoriCatatan == null)
            {
                return NotFound();
            }

            return View(kategoriCatatan);
        }

        // GET: KategoriCatatans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KategoriCatatans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKategori,NamaKategori")] KategoriCatatan kategoriCatatan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kategoriCatatan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kategoriCatatan);
        }

        // GET: KategoriCatatans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategoriCatatan = await _context.KategoriCatatan.FindAsync(id);
            if (kategoriCatatan == null)
            {
                return NotFound();
            }
            return View(kategoriCatatan);
        }

        // POST: KategoriCatatans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKategori,NamaKategori")] KategoriCatatan kategoriCatatan)
        {
            if (id != kategoriCatatan.IdKategori)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kategoriCatatan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KategoriCatatanExists(kategoriCatatan.IdKategori))
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
            return View(kategoriCatatan);
        }

        // GET: KategoriCatatans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategoriCatatan = await _context.KategoriCatatan
                .FirstOrDefaultAsync(m => m.IdKategori == id);
            if (kategoriCatatan == null)
            {
                return NotFound();
            }

            return View(kategoriCatatan);
        }

        // POST: KategoriCatatans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kategoriCatatan = await _context.KategoriCatatan.FindAsync(id);
            _context.KategoriCatatan.Remove(kategoriCatatan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KategoriCatatanExists(int id)
        {
            return _context.KategoriCatatan.Any(e => e.IdKategori == id);
        }
    }
}
