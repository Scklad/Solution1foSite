using Homea.Controllers;
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
            string auth = "";
            if(email != null && email != "")
            {
                if (Environment.GetEnvironmentVariable("INTERN") != null)
                {
                    auth = Environment.GetEnvironmentVariable("INTERN");
                }
                MailSenderController ms = new MailSenderController(auth);
                string content = "Nom : " + nom + "<br>Prenom : " + prenom + "<br>Email : " + email + "<br>Tel : " + tel + "<br>Demande : " + demande;
                string content_customers = "Bonjour, <br><br>Votre demande de contact à bien été prise en compte, <br>je prendrais contact avec vous aussi rapidement que possible.<br><br>Je vous souhaite une excellente journée,<br><br>Cordialement,<br>CHEREAULT Damien";
                string email_contact = "contact@solution1fo.fr";
                string subject = "Demande de contact";
                ms.sendMail(email_contact, content, subject);
                ms.sendMail(email, content_customers, subject);
            }
            return View();
        }

        [Route("/competences")]
        public IActionResult Competences()
        {
            return View();
        }

        [Route("/services")]
        public IActionResult Services()
        {
            return View();
        }

        [Route("/tarifs")]
        public IActionResult Tarifs()
        {
            return View();
        }
    }
}
