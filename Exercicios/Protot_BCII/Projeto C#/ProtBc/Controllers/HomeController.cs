using Microsoft.AspNetCore.Mvc;
using ProtBc.Models;
using System.Diagnostics;

namespace ProtBc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Método para a página inicial
        public IActionResult Index()
        {
            return View();
        }

        // Método para a página de privacidade
        public IActionResult Privacy()
        {
            return View();
        }

        // Método para exibir a página de erro
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
