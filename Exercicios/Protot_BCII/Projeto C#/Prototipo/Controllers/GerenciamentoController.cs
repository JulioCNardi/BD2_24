using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Prototipo.Controllers
{
    public class GerenciamentoController : Controller
    {
        public IActionResult Gerenciamento()
        {
            return View(); // Isso irá procurar por Gerenciamento.cshtml na pasta correta
        }

        public class Item
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Descricao { get; set; }
        }

    }
}
