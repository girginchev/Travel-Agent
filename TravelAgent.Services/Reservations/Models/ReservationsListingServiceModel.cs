namespace TravelAgent.Services.Reservations.Models
{
    using System;

    public class ReservationsListingServiceModel
    {
        public string Id { get; set; }

        public DateTime ReservationTime { get; set; }

        public bool IsFinalized { get; set; }

        public string TourstId { get; set; }

        public string TouristFirstName { get; set; }

        public string TouristLastName { get; set; }

        public int SeatNumber { get; set; }
    }
}
