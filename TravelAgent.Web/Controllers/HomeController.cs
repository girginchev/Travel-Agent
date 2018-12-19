namespace TravelAgent.Web.Controllers
{
    using System;
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using TravelAgent.Services.Mail;
    using TravelAgent.Services.Tours;
    using TravelAgent.Web.Models;
    using TravelAgent.Web.Models.Contacts;
    using TravelAgent.Web.Models.Tours;

    public class HomeController : Controller
    {
        private readonly IToursService tours;
        private readonly IMailService mail;

        public HomeController(IToursService tours, IMailService mail)
        {
            this.tours = tours;
            this.mail = mail;
        }

        public IActionResult Index()
        {
            var topTours = new ToursIndexViewModel
            {
                TopTours = tours.TopTours(),
                Albania = tours.TopAlbania(),
                Austria = tours.TopAustria(),
                Bulgaria = tours.TopBulgaria(),
                 Croatia = tours.TopCroatia(),
                  Greece = tours.TopGreece(),
                   Macedonia = tours.TopMacedonia(),
                    Romania = tours.TopRomania(),
                     Serbia = tours.TopSerbia(),
            };
            return View(topTours);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult CompanyServices()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult PrivacyPolicy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendNotificationMessage(NotificationFormViewModel model)
        {
            
            var message = $"{model.FirstName} {model.LastName} {Environment.NewLine}{model.Email}{Environment.NewLine}{model.Subject}{Environment.NewLine}{model.Message}";
            mail.SendEmail("girginchev@abv.bg", "TravelAgentWeb - notification", message);

            return RedirectToAction("Index");
        }
    }
}
