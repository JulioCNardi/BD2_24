using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProtBc.Models;

namespace ProtBc.Controllers
{
    public class ResultadoesController : Controller
    {
        private readonly CompeticaoDbContext _context;

        public ResultadoesController(CompeticaoDbContext context)
        {
            _context = context;
        }

        // GET: Resultadoes
        public async Task<IActionResult> Index()
        {
            var competicaoDbContext = _context.Resultados.Include(r => r.Competicao).Include(r => r.Equipe);
            return View(await competicaoDbContext.ToListAsync());
        }

        // GET: Resultadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultado = await _context.Resultados
                .Include(r => r.Competicao)
                .Include(r => r.Equipe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resultado == null)
            {
                return NotFound();
            }

            return View(resultado);
        }

        // GET: Resultadoes/Create
        public IActionResult Create()
        {
            ViewData["CompeticaoId"] = new SelectList(_context.Competicoes, "Id", "Id");
            ViewData["EquipeId"] = new SelectList(_context.Equipes, "Id", "Id");
            return View();
        }

        // POST: Resultadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompeticaoId,EquipeId,Pontos")] Resultado resultado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resultado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompeticaoId"] = new SelectList(_context.Competicoes, "Id", "Id", resultado.CompeticaoId);
            ViewData["EquipeId"] = new SelectList(_context.Equipes, "Id", "Id", resultado.EquipeId);
            return View(resultado);
        }

        // GET: Resultadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultado = await _context.Resultados.FindAsync(id);
            if (resultado == null)
            {
                return NotFound();
            }
            ViewData["CompeticaoId"] = new SelectList(_context.Competicoes, "Id", "Id", resultado.CompeticaoId);
            ViewData["EquipeId"] = new SelectList(_context.Equipes, "Id", "Id", resultado.EquipeId);
            return View(resultado);
        }

        // POST: Resultadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompeticaoId,EquipeId,Pontos")] Resultado resultado)
        {
            if (id != resultado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resultado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResultadoExists(resultado.Id))
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
            ViewData["CompeticaoId"] = new SelectList(_context.Competicoes, "Id", "Id", resultado.CompeticaoId);
            ViewData["EquipeId"] = new SelectList(_context.Equipes, "Id", "Id", resultado.EquipeId);
            return View(resultado);
        }

        // GET: Resultadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultado = await _context.Resultados
                .Include(r => r.Competicao)
                .Include(r => r.Equipe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resultado == null)
            {
                return NotFound();
            }

            return View(resultado);
        }

        // POST: Resultadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resultado = await _context.Resultados.FindAsync(id);
            if (resultado != null)
            {
                _context.Resultados.Remove(resultado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResultadoExists(int id)
        {
            return _context.Resultados.Any(e => e.Id == id);
        }
    }
}
