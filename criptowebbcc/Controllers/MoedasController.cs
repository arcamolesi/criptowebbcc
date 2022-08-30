using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using criptowebbcc.Models;

namespace criptowebbcc.Controllers
{
    public class MoedasController : Controller
    {
        private readonly Contexto _context;

        public MoedasController(Contexto context)
        {
            _context = context;
        }

        // GET: Moedas
        public async Task<IActionResult> Index()
        {
              return View(await _context.moedas.ToListAsync());
        }

        // GET: Moedas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.moedas == null)
            {
                return NotFound();
            }

            var moeda = await _context.moedas
                .FirstOrDefaultAsync(m => m.id == id);
            if (moeda == null)
            {
                return NotFound();
            }

            return View(moeda);
        }

        // GET: Moedas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Moedas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,descricao,compra,venda")] Moeda moeda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moeda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(moeda);
        }

        // GET: Moedas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.moedas == null)
            {
                return NotFound();
            }

            var moeda = await _context.moedas.FindAsync(id);
            if (moeda == null)
            {
                return NotFound();
            }
            return View(moeda);
        }

        // POST: Moedas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,descricao,compra,venda")] Moeda moeda)
        {
            if (id != moeda.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moeda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoedaExists(moeda.id))
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
            return View(moeda);
        }

        // GET: Moedas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.moedas == null)
            {
                return NotFound();
            }

            var moeda = await _context.moedas
                .FirstOrDefaultAsync(m => m.id == id);
            if (moeda == null)
            {
                return NotFound();
            }

            return View(moeda);
        }

        // POST: Moedas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.moedas == null)
            {
                return Problem("Entity set 'Contexto.moedas'  is null.");
            }
            var moeda = await _context.moedas.FindAsync(id);
            if (moeda != null)
            {
                _context.moedas.Remove(moeda);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoedaExists(int id)
        {
          return _context.moedas.Any(e => e.id == id);
        }
    }
}
