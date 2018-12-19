namespace TravelAgent.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TravelAgent.Services.Tours;
    using TravelAgent.Web.Models.Tours;

    public class ToursController : Controller
    {
        private readonly IToursService tours;

        public ToursController(IToursService tours)
        {
            this.tours = tours;
        }

        public IActionResult Bulgaria(int page = 1)
        {
            var toursBulgaria = new ToursViewModel
            {
                Tours = tours.Bulgaria(page),
                TotalTours = this.tours.TotalBulgaria(),
                CurrentPage = page
            };
            return View(toursBulgaria);
        }

        public IActionResult Abroad(int page = 1)
        {
            var toursAbroad = new ToursViewModel
            {
                Tours = tours.Abroad(page),
                TotalTours = this.tours.TotalAbroad(),
                CurrentPage = page
            };
            return View(toursAbroad);
        }

        public IActionResult All(int page = 1)
        {
            var allTours = new ToursViewModel
            {
                Tours = tours.All(page),
                TotalTours = this.tours.Total(),
                CurrentPage = page
            };
            return View(allTours);
        }

        public IActionResult ByMonth(int month, int page = 1)
        {
            var toursByMonth = new ToursViewModel
            {
                Tours = tours.ByMonth(month, page),
                TotalTours = this.tours.TotalForMonth(month),
                CurrentPage = page
            };
            return View(toursByMonth);
        }

        public IActionResult Search(string searchTerm, int page = 1)
        {
            var toursBySearchTerm = new ToursViewModel
            {
                Tours = tours.BySearchTerm(searchTerm, page),
                TotalTours = this.tours.TotalBySearchTerm(searchTerm),
                CurrentPage = page
            };
            return View(toursBySearchTerm);
        }

        public IActionResult SearchByPrice(decimal priceFrom, decimal priceTo, int page = 1)
        {
            var toursBySearchTerm = new ToursViewModel
            {
                Tours = tours.ByPriceRange(priceFrom, priceTo, page),
                TotalTours = this.tours.TotalByPriceRange(priceFrom, priceTo),
                CurrentPage = page
            };
            return View(toursBySearchTerm);
        }

        public IActionResult Details(int id)
        {
            return View(this.tours.ById(id));
        }
    }
}
