namespace TravelAgent.Web.Areas.Admin.Controllers.Tours
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.IO;
    using System.Linq;
    using TravelAgent.Services.Admin;
    using TravelAgent.Services.Tours.Models;
    using TravelAgent.Web.Areas.Admin.Models.EditTour;
    using TravelAgent.Web.Infrastructure.Extensions;

    [Area(WebConstants.AdminArea)]
    [Authorize(Roles = WebConstants.AdministratorRole)]
    public class EditTourController : Controller
    {
        private readonly IAdminTourService tours;

        public EditTourController(IAdminTourService tours)
        {
            this.tours = tours;
        }

        public IActionResult EditHeader(int id)
        {
            var tour = tours.ById(id);

            if (tour == null)
            {
                return NotFound();
            }

            return View(new EditTourHeaderViewModel()
            {
                Title = tour.Title,
                HeaderImage = tour.HeaderImage
            });
        }

        [HttpPost]
        public IActionResult EditHeader(int id, IFormFile headerImage, EditTourHeaderViewModel model)
        {

            byte[] pic = null;
            if (headerImage != null)
            {
                using (var stream = new MemoryStream())
                {
                    headerImage?.CopyTo(stream);
                    pic = stream.ToArray();
                }
            }

            var success = tours.EditHeader(id, pic, model.Title);

            if (success)
            {
                TempData.AddSuccessMessage($"Tour {id} header edited successfully!");
            }
            else
            {
                TempData.AddErrorMessage($"Header of tour {id} was not changed");
            }

            return base.RedirectToAction(
                nameof(Web.Controllers.ToursController.Details), "Tours", new { area = string.Empty, id = id });
        }

        public IActionResult EditTourDay(int id, int tourDayId)
        {
            var tour = tours.ById(id);
            var index = tourDayId - 1;
            if (tour == null)
            {
                return NotFound();
            }

            return View(new EditTourDayViewModel()
            {
                DayId = tourDayId,
                DayTitle = tour.TourDays[index].DayTitle,
                DayDescription = tour.TourDays[index].DayDescription,
                DayPicture = tour.TourDays[index].DayPicture,
            });
        }

        [HttpPost]
        public IActionResult EditTourDay(int id, IFormFile dayPicture, EditTourDayViewModel model)
        {

            byte[] pic = null;
            if (dayPicture != null)
            {
                using (var stream = new MemoryStream())
                {
                    dayPicture?.CopyTo(stream);
                    pic = stream.ToArray();
                }
            }

            var success = tours.EditТourDay(id, model.DayId, pic, model.DayTitle, model.DayDescription);

            if (success)
            {
                TempData.AddSuccessMessage($"TourDay {model.DayId} of Tour {id} was edited successfully!");
            }
            else
            {
                TempData.AddErrorMessage($"TourDay {model.DayId} of Tour {id} was not changed");
            }

            return base.RedirectToAction(
                nameof(Web.Controllers.ToursController.Details), "Tours", new { area = string.Empty, id = id });
        }

        public IActionResult EditAdditionalService(int id, int serviceId)
        {
            var tour = tours.ById(id);
            var index = serviceId - 1;
            if (tour == null)
            {
                return NotFound();
            }

            return View(new EditAdditionalServiceViewModel()
            {
                ServiceId = serviceId,
                Content = tour.AdditionalSevices[index].Content,
                Price = tour.AdditionalSevices[index].Price,
            });
        }

        [HttpPost]
        public IActionResult EditAdditionalService(int id, EditAdditionalServiceViewModel model)
        {
            var success = tours.EditAdditionalService(id, model.ServiceId, model.Content, model.Price);

            if (success)
            {
                TempData.AddSuccessMessage($"Additional service {model.ServiceId} of Tour {id} was edited successfully!");
            }
            else
            {
                TempData.AddErrorMessage($"Additional service {model.ServiceId} of Tour {id} was not changed");
            }

            return base.RedirectToAction(
                 nameof(Web.Controllers.ToursController.Details), "Tours", new { area = string.Empty, id = id });
        }

        public IActionResult EditUsefulInformation(int id)
        {
            var tour = tours.ById(id);
            if (tour == null)
            {
                return NotFound();
            }

            return View(new EditUsefulInformaionViewModel
            {
                Content = tour.UsefulInformation,
                TourId = id
            });
        }

        [HttpPost]
        public IActionResult EditUsefulInformation(int id, EditUsefulInformaionViewModel model)
        {
            var success = tours.EditUsefulInformation(id, model.Content);

            if (success)
            {
                TempData.AddSuccessMessage($"Useful information of Tour {id} was edited successfully!");
            }
            else
            {
                TempData.AddErrorMessage($"Useful information of Tour {id} was not changed");
            }

            return base.RedirectToAction(
                 nameof(Web.Controllers.ToursController.Details), "Tours", new { area = string.Empty, id = id });
        }

        public IActionResult EditPriceIncludes(int id)
        {
            var tour = tours.ById(id);
            if (tour == null)
            {
                return NotFound();
            }

            return View(new EditPriceIncludesViewModel
            {
                Content = tour.PriceIncludes,
                TourId = id
            });
        }

        [HttpPost]
        public IActionResult EditPriceIncludes(int id, EditPriceIncludesViewModel model)
        {
            var success = tours.EditPriceIncludes(id, model.Content);

            if (success)
            {
                TempData.AddSuccessMessage($"Content price includes of Tour {id} was edited successfully!");
            }
            else
            {
                TempData.AddErrorMessage($"Content price includes of Tour {id} was not changed");
            }

            return base.RedirectToAction(
                 nameof(Web.Controllers.ToursController.Details), "Tours", new { area = string.Empty, id = id });
        }

        public IActionResult EditPriceDoesNotIncludes(int id)
        {
            var tour = tours.ById(id);
            if (tour == null)
            {
                return NotFound();
            }

            return View(new EditPriceDoesNotIncludesViewModel
            {
                Content = tour.PriceDoesNotIncludes,
                TourId = id
            });
        }

        [HttpPost]
        public IActionResult EditPriceDoesNotIncludes(int id, EditPriceDoesNotIncludesViewModel model)
        {
            var success = tours.EditPricePriceDoesNotIncludes(id, model.Content);

            if (success)
            {
                TempData.AddSuccessMessage($"Content price doesn't includes of Tour {id} was edited successfully!");
            }
            else
            {
                TempData.AddErrorMessage($"Content price doesn't includes of Tour {id} was not changed");
            }

            return base.RedirectToAction(
                 nameof(Web.Controllers.ToursController.Details), "Tours", new { area = string.Empty, id = id });
        }

        public IActionResult EditTrip(int id, int tripId)
        {
            var tour = tours.ById(id);
            if (tour == null)
            {
                return NotFound();
            }
            var trip = tour.Trips.Where(t => t.Id == tripId).Select(t=> new EditTripViewModel
            {
                 Id = t.Id,
                 StartDate = t.StartDate,
                  EndDate = t.EndDate,
                   Price = t.Price,
                    TourId = id
            }).FirstOrDefault();
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        [HttpPost]
        public IActionResult EditTrip(EditTripViewModel model)
        {
            var success = tours.EditTrip(model.Id, model.StartDate, model.EndDate, model.Price);

            if (success)
            {
                TempData.AddSuccessMessage($"Trip {model.Id} was edited successfully!");
            }
            else
            {
                TempData.AddErrorMessage($"Trip {model.Id}  was not changed");
            }

            return base.RedirectToAction(
                 nameof(Web.Controllers.ToursController.All), "Tours", new { area = string.Empty, id = model.TourId });
        }

        [HttpPost]
        public IActionResult EditDestinationType(int tourId, TourDetailsServiceModel model)
        {
            this.tours.ChangeDestinationType(tourId, model.DestinationType);

            return base.RedirectToAction(
                 nameof(Web.Controllers.ToursController.Details), "Tours", new { area = string.Empty, id = tourId });
        }
    }
}
