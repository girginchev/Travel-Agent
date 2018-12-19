namespace TravelAgent.Services.Reservations.Models
{
    using System;
    using System.Collections.Generic;

    public class ReservationsDetailsServiceModel
    {
        public string Id { get; set; }

        public List<AddAdditionalServicesModel> IncludedAdditionalServices { get; set; }

        public decimal TotalPrice { get; set; }

        public string TourTitle { get; set; }

        public DateTime ReservationTime { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool IsFinalized { get; set; }

        public string FirstNameCyrilic { get; set; }

        public string SurNameCyrilic { get; set; }

        public string LastNameCyrilic { get; set; }

        public string FirstNameLatin { get; set; }

        public string SurNameLatin { get; set; }

        public string LastNameLatin { get; set; }

        public string EGN { get; set; }

        public string PasportNumber { get; set; }

        public DateTime PasportDateOfIssue { get; set; }

        public DateTime PasportValidityDate { get; set; }

        public string IdCard { get; set; }

        public DateTime IdCardDateOfIssue { get; set; }

        public DateTime IdCardValidityDate { get; set; }

        public string Adress { get; set; }

        public int TripId { get; set; }

        public DateTime TripStartDate { get; set; }

        public int SeatNumber { get; set; }
    }
}
