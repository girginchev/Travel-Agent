namespace TravelAgent.Services.Tours.Models
{
    using System.Collections.Generic;

    public class BusSeatsListingServiceModel
    {
        public int TripId { get; set; }

        public int BusId { get; set; }

        public List<int> SeatId { get; set; }

        public List<int> SeatNumbers { get; set; }

        public List<bool> IsReserved { get; set; }
    }
}
