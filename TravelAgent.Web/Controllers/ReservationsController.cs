namespace TravelAgent.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using TravelAgent.Services.Admin;
    using TravelAgent.Services.Mail;
    using TravelAgent.Services.Reservations;
    using TravelAgent.Services.Reservations.Models;
    using TravelAgent.Web.Infrastructure.Extensions;
    using TravelAgent.Web.Models.Reservations;

    public class ReservationsController : Controller
    {
        private readonly IReservationService reservationService;
        private readonly IMailService emailService;
        private readonly IAdminTourService tours;

        public ReservationsController(IReservationService reservationService, IMailService emailService,
            IAdminTourService tours)
        {
            this.reservationService = reservationService;
            this.emailService = emailService;
            this.tours = tours;
        }

        public IActionResult AddReservation(int id)
        {
            var model = reservationService.BusSeatsByTripId(id);
            model.AdditionalServices = reservationService.AdditionalServicesByTripId(id);
            model.TourTitle = reservationService.GetTourName(id);
            model.BasePrice = reservationService.GetBasePrice(id);
            model.TripStartDate = reservationService.GetStartDate(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult AddReservation(AddReservationServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var additionalServicesSelected = new List<AddAdditionalServicesModel>();
            for (int i = 0; i < model.AdditionalServices.Count; i++)
            {
                if (model.AdditionalServices[i].IsSelected == true)
                {
                    additionalServicesSelected.Add(model.AdditionalServices[i]);
                }
            }

            int reservedSeat = -1;
            for (int i = 0; i < model.IsReserved.Count; i++)
            {
                if (model.IsReserved[i] == true)
                {
                    reservedSeat = model.SeatId[i];
                }
            }
            if (reservedSeat == -1)
            {
                reservedSeat = reservationService.GetFirstFreeSeat(model.TripId);
            }

            var reservationId = $"{model.TripId}{reservedSeat}{model.LastNameLatin}";
            var totalPrice = model.BasePrice;
            foreach (var item in additionalServicesSelected)
            {
                totalPrice += item.Price;
            }

            this.reservationService.CreateReservation(reservationId, model.TripId, model.EGN,
                model.Email, model.Password, model.Phone, reservedSeat, additionalServicesSelected,
                totalPrice, model.TourTitle, model.FirstNameCyrilic, model.SurNameCyrilic, model.LastNameCyrilic,
                model.FirstNameLatin, model.SurNameLatin, model.LastNameLatin,
                model.PasportNumber, DateTime.Parse(model.PasportDateOfIssue), DateTime.Parse(model.PasportValidityDate),
                model.IdCard, DateTime.Parse(model.IdCardDateOfIssue), DateTime.Parse(model.IdCardValidityDate), model.Address, 
                model.GDPRConfirm, model.GDPRRead);


            TempData.AddSuccessMessage($"Your reservation was submitted successfuly! Please check your email for more details.");
            emailService.SendReservationEmail(model.Email, reservationId);

            return RedirectToAction(
            nameof(HomeController.Index),
              "Home",
            new { area = string.Empty });
        }

        public IActionResult Check()
        {
            return View(new ClientFormViewModel());
        }

        [HttpPost]
        public IActionResult Check(ClientFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var email = reservationService.GetEmailByReservationId(model.ReservationId);

            if (email!=model.Email)
            {
                return BadRequest();
            }

            var reservation = reservationService.FindReservation(model.ReservationId);

            if (reservation == null)
            {
                return BadRequest();
            }

            return View("Details",reservation);
        }
    }
}
