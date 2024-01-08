using Microsoft.AspNetCore.Mvc;
using Solution1fo.Models;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace Solution1fo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/accueil")]
        public IActionResult Accueil()
        {
            return View("Index");
        }

        [Route("/mentions-legales")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("/contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("/realisation")]
        public IActionResult Realisation()
        {
            return View();
        }

        [Route("/send-contact")]
        public IActionResult SendContact(string nom, string prenom, string email, string tel, string demande)
        {
            return View();
        }
    }
}
