namespace TravelAgent.Services.Reservations.Models
{
    using System;
    using System.Collections.Generic;

    public class ReservationShortDetailsServiceModel
    {
        public List<AddAdditionalServicesModel> IncludedAdditionalServices { get; set; }

        public decimal TotalPrice { get; set; }

        public string TourTitle { get; set; }

        public bool IsFinalized { get; set; }

        public string FirstNameLatin { get; set; }
        
        public string LastNameLatin { get; set; }

        public DateTime TripStartDate { get; set; }

        public int SeatNumber { get; set; }
    }
}
