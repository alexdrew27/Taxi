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
    public class ComandasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComandasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Comandas
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Comenzi.ToListAsync());
        }

        // GET: Comandas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comanda = await _context.Comenzi
                .FirstOrDefaultAsync(m => m.ComandaId == id);
            if (comanda == null)
            {
                return NotFound();
            }

            return View(comanda);
        }

        // GET: Comandas/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: Comandas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComandaId,Nume,NrTelefon,Email,CartierCurent,StradaCurenta,DetaliiAdresaCurent,CartierDestinatie,StradaDestinatie,DetaliiAdresaDestinatie,Status")] Comanda comanda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comanda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            return View(comanda);
        }

        // GET: Comandas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comanda = await _context.Comenzi.FindAsync(id);
            if (comanda == null)
            {
                return NotFound();
            }
            return View(comanda);
        }

        // POST: Comandas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComandaId,Nume,NrTelefon,Email,CartierCurent,StradaCurenta,DetaliiAdresaCurent,CartierDestinatie,StradaDestinatie,DetaliiAdresaDestinatie,Status,Timp")] Comanda comanda)
        {
            if (id != comanda.ComandaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comanda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComandaExists(comanda.ComandaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Comenzi));
            }
            return View(comanda);
        }

        // GET: Comandas/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comanda = await _context.Comenzi
                .FirstOrDefaultAsync(m => m.ComandaId == id);
            if (comanda == null)
            {
                return NotFound();
            }

            return View(comanda);
        }

        // POST: Comandas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comanda = await _context.Comenzi.FindAsync(id);
            _context.Comenzi.Remove(comanda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComandaExists(int id)
        {
            return _context.Comenzi.Any(e => e.ComandaId == id);
        }

        [Authorize(Roles = "Sofer")]
        public async Task<IActionResult> Comenzi()
        {
                return View(await _context.Comenzi.Where(x => x.Status == false).ToListAsync());
            
            
        }
       
    }
}
