namespace TravelAgent.Web.Areas.Admin.Controllers.Tours
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.IO;
    using TravelAgent.Services.Admin;
    using TravelAgent.Services.Html;
    using TravelAgent.Services.Tours.Models;
    using TravelAgent.Web.Areas.Admin.Models.Tours;
    using TravelAgent.Web.Infrastructure.Extensions;

    [Area(WebConstants.AdminArea)]
    [Authorize(Roles = WebConstants.AdministratorRole)]
    public class ToursController : Controller
    {
        private readonly IAdminTourService tours;
        private readonly IHtmlService html;

        public ToursController(IAdminTourService tours, IHtmlService html)
        {
            this.tours = tours;
            this.html = html;
        }

        public IActionResult Create()
        {
            return View(new AddToursFormViewModel());
        }

        [HttpPost]
        public IActionResult Create(AddToursFormViewModel model,
            IFormFile headerImage,
            List<IFormFile> tourDayPictures)
        {
            using (var stream = new MemoryStream())
            {
                headerImage?.CopyTo(stream);
                model.HeaderImage = stream.ToArray();
            }

            foreach (var pic in tourDayPictures)
            {
                if (pic.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        pic.CopyTo(stream);
                        model.TourDayPictures.Add(stream.ToArray());
                    }
                }
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.tours.Create(
                model.Title,
                model.HeaderImage,
                model.TourDayPictures,
                model.TourDayTitles,
                model.TourDayDescriptions,
                model.StartDate,
                model.EndDate,
                model.Price,
                model.BusSeats,
                model.Nights,
                model.StartingPoint,
                model.Destination,
                model.DestinationType.ToString(),
                this.html.Sanitize(model.Description),
                model.UsefulInformation,
                model.PriceIncludes,
                model.PriceDoesNotIncludes,
                model.AdditionalServicesContents,
                model.AdditionalSerivicesPrices);

            TempData.AddSuccessMessage($"Tour {model.Title} created successfully!");

            return base.RedirectToAction(
                nameof(Web.Controllers.ToursController.All), "Tours", new { area = string.Empty });
        }

        public IActionResult AddTrip(int id)
        {
            var trip = new AddTripFormViewModel()
            {
                Id = id
            };
            return View(trip);
        }

        [HttpPost]
        public IActionResult AddTrip(AddTripFormViewModel model)
        {

            tours.AddTrip(model.TourId, model.StartDate, model.EndDate, model.Price, model.BusSeatsNumber);

            TempData.AddSuccessMessage($"Trip was successfully added to tour {model.TourId}!");

            return base.RedirectToAction(
                nameof(Web.Controllers.ToursController.Details), "Tours", new { area = string.Empty, id = model.TourId });
        }

        public IActionResult DeleteTrip(int id, int tripId)
        {
            tours.DeleteTrip(id, tripId);

            TempData.AddSuccessMessage($"Trip {tripId} was successfully deleted to tour {id}!");

            return base.RedirectToAction(
                nameof(Web.Controllers.ToursController.Details), "Tours", new { area = string.Empty, id = id });
        }

        public IActionResult AddAdditionalService(int id)
        {
            var service = new AddAdditionalServiceFormViewModel()
            {
                TourId = id
            };
            return View(service);
        }

        [HttpPost]
        public IActionResult AddAdditionalService(AddAdditionalServiceFormViewModel model)
        {
            tours.AddAdditionalService(model.TourId, model.Content, model.Price);

            TempData.AddSuccessMessage($"Additional service was successfully added to tour {model.TourId}!");

            return base.RedirectToAction(
                nameof(Web.Controllers.ToursController.Details), "Tours", new { area = string.Empty, id = model.TourId });
        }

        public IActionResult DeleteService(int id, int serviceId)
        {
            tours.DeleteService(id, serviceId);

            TempData.AddSuccessMessage($"Additional service was successfully deleted to tour {id}!");

            return base.RedirectToAction(
                nameof(Web.Controllers.ToursController.Details), "Tours", new { area = string.Empty, id = id });
        }

        public IActionResult SetAvailableSeats(int id, int tripId)
        {
            var bus = tours.BusSeatsByTripId(tripId);
           
            if (bus == null)
            {
                return NotFound();
            }

            return View(bus);
        }

        [HttpPost]
        public IActionResult SetAvailableSeats(BusSeatsListingServiceModel model)
        {
            tours.SetSeatAvailability(model.SeatId, model.IsReserved, model.SeatNumbers, model.BusId, model.TripId);

            return base.RedirectToAction(
                nameof(Web.Controllers.ToursController.All), "Tours", new { area = string.Empty });
        }
    }
}
