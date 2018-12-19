namespace TravelAgent.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Reservation
    {
        public string Id { get; set; }

        public string Password { get; set; }

        public List<AdditionalService> IncludedAdditionalServices { get; set; }

        public decimal TotalPrice { get; set; }

        public string TourTitle { get; set; }

        public DateTime ReservationTime { get; set; }

        public bool IsFinalized { get; set; }

        public string TourstId { get; set; }
        public User Tourist { get; set; }

        public int TripId { get; set; }
        public Trip Trip { get; set; }

        public int SeatId { get; set; }
        public Seat Seat { get; set; }
    }
}
