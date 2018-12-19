namespace TravelAgent.Web.Areas.Admin.Controllers.Reservations
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TravelAgent.Services.ExcelExport;
    using TravelAgent.Services.Mail;
    using TravelAgent.Services.Reservations;
    using TravelAgent.Web.Areas.Admin.Models.Reservations;
    using TravelAgent.Web.Controllers;
    using TravelAgent.Web.Infrastructure.Extensions;

    [Area(WebConstants.AdminArea)]
    [Authorize(Roles = WebConstants.AdministratorRole)]
    public class ReservationsController : Controller
    {
        private readonly IReservationService reservation;
        private readonly IMailService emailService;
        private readonly IExcelExport excelExport;
        private const string XlsxContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        public ReservationsController(IReservationService reservation, IMailService emailService, IExcelExport excelExport)
        {
            this.reservation = reservation;
            this.emailService = emailService;
            this.excelExport = excelExport;
        }

        public IActionResult All(int tripId)
        {
            var reservations = reservation.GetAllReservationsByTripId(tripId);
            return View(new ReservationsListingViewModel { TripId = tripId, Reservations = reservations });
        }

        public IActionResult Details(string id)
        {
            var result = reservation.GetReservationDetailsByTripId(id);
            return View(result);
        }

        public IActionResult Report(int tripId)
        {
            byte[] reportBytes;
            using (var package = excelExport.CreateExcelPackage(reservation.GetAllReservationsByTripIdFullDetails(tripId)))
            {
                reportBytes = package.GetAsByteArray();
            }

            return File(reportBytes, XlsxContentType, $"{tripId}.xlsx");
        }

        [HttpPost]
        public IActionResult Confirm(bool IsFinalized, string id)
        {
            var success = reservation.ConfirmReservation(IsFinalized, id);
            if (success)
            {
                TempData.AddSuccessMessage($"Your reservation with was confirmed successfuly with your payment");
                var email = reservation.GetEmailByReservationId(id);
                emailService.SendReservationConfirmEmail(email, id);

                return RedirectToAction(
                nameof(ToursController.All),
                  "Tours",
                new { area = string.Empty });
            }
            else
            {
                TempData.AddSuccessMessage($"Reservation {id} is no longer confirmed");

                return RedirectToAction(
                    nameof(ToursController.All),
                      "Tours",
                    new { area = string.Empty });
            }
        }
    }
}
