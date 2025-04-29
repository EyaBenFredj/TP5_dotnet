﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestoManager_YourName.Models.RestosModel;

namespace TP5.Controllers
{
    public class AvisController : Controller
    {
        private readonly RestosDbContext _context;

        public AvisController(RestosDbContext context)
        {
            _context = context;
        }

        // GET: Avis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Avis.ToListAsync());
        }

        // GET: Avis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avis = await _context.Avis
                .FirstOrDefaultAsync(m => m.CodeAvis == id);
            if (avis == null)
            {
                return NotFound();
            }

            return View(avis);
        }

        // GET: Avis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Avis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodeAvis,NomPersonne,Note,Commentaire,NumResto")] Avis avis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(avis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(avis);
        }

        // GET: Avis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avis = await _context.Avis.FindAsync(id);
            if (avis == null)
            {
                return NotFound();
            }
            return View(avis);
        }

        // POST: Avis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodeAvis,NomPersonne,Note,Commentaire,NumResto")] Avis avis)
        {
            if (id != avis.CodeAvis)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvisExists(avis.CodeAvis))
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
            return View(avis);
        }

        // GET: Avis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avis = await _context.Avis
                .FirstOrDefaultAsync(m => m.CodeAvis == id);
            if (avis == null)
            {
                return NotFound();
            }

            return View(avis);
        }

        // POST: Avis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var avis = await _context.Avis.FindAsync(id);
            if (avis != null)
            {
                _context.Avis.Remove(avis);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> AvisParRestaurant(int codeResto)
        {
            var avis = await _context.Avis
                .Where(a => a.NumResto == codeResto)
                .Include(a => a.LeResto)
                .ToListAsync();

            var resto = await _context.Restaurants.FindAsync(codeResto);

            ViewBag.Restaurant = resto?.NomResto ?? "Inconnu";
            return View(avis);
        }
        private bool AvisExists(int id)
        {
            return _context.Avis.Any(e => e.CodeAvis == id);
        }
    }
}
