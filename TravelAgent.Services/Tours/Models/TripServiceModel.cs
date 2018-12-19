namespace TravelAgent.Services.Tours.Models
{
    using System;
    using System.Collections.Generic;

    public class TripServiceModel
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public List<BusServiceModel> Buses { get; set; } = new List<BusServiceModel>();
    }
}
