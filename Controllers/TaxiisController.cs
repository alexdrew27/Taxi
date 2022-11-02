using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Taxi.Data;
using Taxi.Models;

namespace Taxi.Controllers
{
    public class TaxiisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaxiisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Taxiis
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Taxi.ToListAsync());
        }

        // GET: Taxiis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxii = await _context.Taxi
                .FirstOrDefaultAsync(m => m.TaxiiId == id);
            if (taxii == null)
            {
                return NotFound();
            }

            return View(taxii);
        }

        // GET: Taxiis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Taxiis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaxiiId,Marca,Nr")] Taxii taxii)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taxii);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taxii);
        }

        // GET: Taxiis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxii = await _context.Taxi.FindAsync(id);
            if (taxii == null)
            {
                return NotFound();
            }
            return View(taxii);
        }

        // POST: Taxiis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaxiiId,Marca,Nr")] Taxii taxii)
        {
            if (id != taxii.TaxiiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taxii);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaxiiExists(taxii.TaxiiId))
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
            return View(taxii);
        }

        // GET: Taxiis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxii = await _context.Taxi
                .FirstOrDefaultAsync(m => m.TaxiiId == id);
            if (taxii == null)
            {
                return NotFound();
            }

            return View(taxii);
        }

        // POST: Taxiis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taxii = await _context.Taxi.FindAsync(id);
            _context.Taxi.Remove(taxii);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaxiiExists(int id)
        {
            return _context.Taxi.Any(e => e.TaxiiId == id);
        }
    }
}
