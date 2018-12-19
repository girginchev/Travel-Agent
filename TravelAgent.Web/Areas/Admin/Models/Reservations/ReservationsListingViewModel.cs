namespace TravelAgent.Web.Areas.Admin.Models.Reservations
{
    using System.Collections.Generic;
    using TravelAgent.Services.Reservations.Models;

    public class ReservationsListingViewModel
    {
        public int TripId { get; set; }

        public List<ReservationsListingServiceModel> Reservations {get; set;}
    }
}
