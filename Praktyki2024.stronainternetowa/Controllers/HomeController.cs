using Microsoft.AspNetCore.Mvc;
using Praktyki2024.stronainternetowa.Models;
using System.Diagnostics;

namespace Praktyki2024.stronainternetowa.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult PageOne()
        {
            var statystyki = new PageOne(
                2007,
                1000,
                "BMV",
                4,
                "Osobowy");
            return View(statystyki);
        }
        public IActionResult PageSecond()
        {
            var statystyki = new PageSecond(
                2024,
                0,
                "Ford Mustang",
                2,
                "Sportowy");
            return View(statystyki);
        }
        public IActionResult PageThird()
        {
            var statystyki = new PageThird(
                2000,
                30000,
                "Mercedes",
                2,
                "Ciezarowy");
            return View(statystyki);
        }
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitContact(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Dziêkujemy za kontakt!";
                return View("Contact");
            }

            return View("Contact", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
