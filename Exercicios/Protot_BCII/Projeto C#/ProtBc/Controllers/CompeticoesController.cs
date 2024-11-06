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
    public class CompeticoesController : Controller
    {
        private readonly CompeticaoDbContext _context;

        public CompeticoesController(CompeticaoDbContext context)
        {
            _context = context;
        }

        // GET: Competicoes
        public async Task<IActionResult> Index()
        {
            var competicaoDbContext = _context.Competicoes.Include(c => c.Modalidade);
            return View(await competicaoDbContext.ToListAsync());
        }

        // GET: Competicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competico = await _context.Competicoes
                .Include(c => c.Modalidade)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (competico == null)
            {
                return NotFound();
            }

            return View(competico);
        }

        // GET: Competicoes/Create
        public IActionResult Create()
        {
            ViewData["ModalidadeId"] = new SelectList(_context.Modalidades, "Id", "Id");
            return View();
        }

        // POST: Competicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DataInicio,DataFim,ModalidadeId")] Competico competico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(competico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModalidadeId"] = new SelectList(_context.Modalidades, "Id", "Id", competico.ModalidadeId);
            return View(competico);
        }

        // GET: Competicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competico = await _context.Competicoes.FindAsync(id);
            if (competico == null)
            {
                return NotFound();
            }
            ViewData["ModalidadeId"] = new SelectList(_context.Modalidades, "Id", "Id", competico.ModalidadeId);
            return View(competico);
        }

        // POST: Competicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DataInicio,DataFim,ModalidadeId")] Competico competico)
        {
            if (id != competico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(competico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompeticoExists(competico.Id))
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
            ViewData["ModalidadeId"] = new SelectList(_context.Modalidades, "Id", "Id", competico.ModalidadeId);
            return View(competico);
        }

        // GET: Competicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competico = await _context.Competicoes
                .Include(c => c.Modalidade)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (competico == null)
            {
                return NotFound();
            }

            return View(competico);
        }

        // POST: Competicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var competico = await _context.Competicoes.FindAsync(id);
            if (competico != null)
            {
                _context.Competicoes.Remove(competico);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompeticoExists(int id)
        {
            return _context.Competicoes.Any(e => e.Id == id);
        }
    }
}
