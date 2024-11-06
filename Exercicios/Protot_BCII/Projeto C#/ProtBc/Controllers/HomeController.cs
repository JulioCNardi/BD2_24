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

        // M�todo para a p�gina inicial
        public IActionResult Index()
        {
            return View();
        }

        // M�todo para a p�gina de privacidade
        public IActionResult Privacy()
        {
            return View();
        }

        // M�todo para exibir a p�gina de erro
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
