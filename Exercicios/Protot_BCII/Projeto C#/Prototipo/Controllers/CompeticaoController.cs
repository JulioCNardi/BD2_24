using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Competicao.Models;  // Namespace correto
using Competicao.Data;    // Namespace correto
using Microsoft.EntityFrameworkCore;

public class CompeticaoController : Controller
{
    private readonly ApplicationDbContext _context;

    public CompeticaoController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Competicao
    public async Task<IActionResult> Index()
    {
        var competicoes = await _context.Competicoes.Include(c => c.Modalidade).ToListAsync();
        return View(competicoes);
    }

    // GET: Competicao/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var competicao = await _context.Competicoes
            .Include(c => c.Modalidade)
            .Include(c => c.Equipes)  // Incluir equipes
            .FirstOrDefaultAsync(m => m.CompeticaoId == id);
        if (competicao == null)
        {
            return NotFound();
        }

        return View(competicao);
    }

    // GET: Competicao/Create
    public IActionResult Create()
    {
        ViewData["ModalidadeId"] = new SelectList(_context.Modalidades, "ModalidadeId", "Nome");
        return View();
    }

    // POST: Competicao/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("CompeticaoId,Nome,DataInicio,ModalidadeId,TipoTorneio")] Competicao competicao)
    {
        if (ModelState.IsValid)
        {
            _context.Add(competicao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["ModalidadeId"] = new SelectList(_context.Modalidades, "ModalidadeId", "Nome", competicao.ModalidadeId);
        return View(competicao);
    }

    // GET: Competicao/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var competicao = await _context.Competicoes.FindAsync(id);
        if (competicao == null)
        {
            return NotFound();
        }
        ViewData["ModalidadeId"] = new SelectList(_context.Modalidades, "ModalidadeId", "Nome", competicao.ModalidadeId);
        return View(competicao);
    }

    public async Task<IActionResult> AddEquipe(int competicaoId)
    {
        var competicao = await _context.Competicoes
            .Include(c => c.Equipes) // Certifique-se de incluir as equipes
            .FirstOrDefaultAsync(c => c.CompeticaoId == competicaoId);
        if (competicao == null)
        {
            return NotFound();
        }

        ViewData["EquipeId"] = new SelectList(_context.Equipes, "EquipeId", "Nome");
        return View(competicao);
    }


    // POST: Competicao/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("CompeticaoId,Nome,DataInicio,ModalidadeId,TipoTorneio")] Competicao competicao)
    {
        if (id != competicao.CompeticaoId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(competicao);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompeticaoExists(competicao.CompeticaoId))
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
        ViewData["ModalidadeId"] = new SelectList(_context.Modalidades, "ModalidadeId", "Nome", competicao.ModalidadeId);
        return View(competicao);
    }

    // GET: Competicao/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var competicao = await _context.Competicoes
            .Include(c => c.Modalidade)
            .FirstOrDefaultAsync(m => m.CompeticaoId == id);
        if (competicao == null)
        {
            return NotFound();
        }

        return View(competicao);
    }

    // POST: Competicao/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var competicao = await _context.Competicoes.FindAsync(id);
        _context.Competicoes.Remove(competicao);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // Método para adicionar equipes a uma competição
    public async Task<IActionResult> AddEquipe(int competicaoId)
    {
        var competicao = await _context.Competicoes.FindAsync(competicaoId);
        if (competicao == null)
        {
            return NotFound();
        }

        ViewData["EquipeId"] = new SelectList(_context.Equipes, "EquipeId", "Nome");
        return View(competicao);
    }

    // POST: Competicao/AddEquipe
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddEquipe(int competicaoId, int equipeId)
    {
        var competicao = await _context.Competicoes.FindAsync(competicaoId);
        var equipe = await _context.Equipes.FindAsync(equipeId);

        if (competicao == null || equipe == null)
        {
            return NotFound();
        }

        // Adicione a equipe à competição
        competicao.Equipes.Add(equipe);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Details), new { id = competicaoId });
    }

    private bool CompeticaoExists(int id)
    {
        return _context.Competicoes.Any(e => e.CompeticaoId == id);
    }
}
