﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using criptowebbcc.Models;

namespace criptowebbcc.Controllers
{
    public class TransacoesController : Controller
    {
        private readonly Contexto _context;

        public TransacoesController(Contexto context)
        {
            _context = context;
        }

        // GET: Transacoes
        public async Task<IActionResult> Index()
        {
            var contexto = _context.transacoes.Include(t => t.conta).
                                      Include(c=>c.conta.cliente).Include(m =>m.conta.moeda);
            return View(await contexto.ToListAsync());
        }

        // GET: Transacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.transacoes == null)
            {
                return NotFound();
            }

            var transacao = await _context.transacoes
                .Include(t => t.conta)
                .FirstOrDefaultAsync(m => m.id == id);
            if (transacao == null)
            {
                return NotFound();
            }

            return View(transacao);
        }

        // GET: Transacoes/Create
        public IActionResult Create()
        {
            var operacao = Enum.GetValues(typeof(Operacao))
            .Cast<Operacao>()
            .Select(e => new SelectListItem
            {
                Value = e.ToString(),
                Text = e.ToString()
            });
            ViewBag.bagOperacao = operacao;

            ViewData["contas"] = new SelectList(_context.contas, "id", "id");
            return View();
        }

        // POST: Transacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,contaid,data,quantidade,valor,operacao")] Transacao transacao)
        {
            if (ModelState.IsValid)
            {

                Conta conta = _context.contas.Find(transacao.contaid);
                if (transacao.operacao == Operacao.Compra)
                    conta.quantidade = conta.quantidade + transacao.quantidade;
                else conta.quantidade = conta.quantidade - transacao.quantidade;

                _context.Update(conta); 

                _context.Add(transacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["contaid"] = new SelectList(_context.contas, "id", "id", transacao.contaid);
            return View(transacao);
        }

        // GET: Transacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.transacoes == null)
            {
                return NotFound();
            }

            var transacao = await _context.transacoes.FindAsync(id);
            if (transacao == null)
            {
                return NotFound();
            }
            ViewData["contaid"] = new SelectList(_context.contas, "id", "id", transacao.contaid);
            return View(transacao);
        }

        // POST: Transacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,contaid,data,quantidade,valor,operacao")] Transacao transacao)
        {
            if (id != transacao.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransacaoExists(transacao.id))
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
            ViewData["contaid"] = new SelectList(_context.contas, "id", "id", transacao.contaid);
            return View(transacao);
        }

        // GET: Transacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.transacoes == null)
            {
                return NotFound();
            }

            var transacao = await _context.transacoes
                .Include(t => t.conta)
                .FirstOrDefaultAsync(m => m.id == id);
            if (transacao == null)
            {
                return NotFound();
            }

            return View(transacao);
        }

        // POST: Transacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.transacoes == null)
            {
                return Problem("Entity set 'Contexto.transacoes'  is null.");
            }
            var transacao = await _context.transacoes.FindAsync(id);
            if (transacao != null)
            {
                _context.transacoes.Remove(transacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransacaoExists(int id)
        {
          return _context.transacoes.Any(e => e.id == id);
        }
    }
}
