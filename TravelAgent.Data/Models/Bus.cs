namespace TravelAgent.Data.Models
{
    using System.Collections.Generic;

    public class Bus
    {
        public int Id { get; set; }

        public int TripId { get; set; }
        public Trip Trip { get; set; }

        public List<Seat> Seats { get; set; } = new List<Seat>();
    }
}
