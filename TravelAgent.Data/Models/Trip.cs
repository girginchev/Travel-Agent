namespace TravelAgent.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Trip
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public int TourId { get; set; }
        public Tour Tour { get; set; }

        public List<Bus> Buses { get; set; } = new List<Bus>();

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

    }
}
