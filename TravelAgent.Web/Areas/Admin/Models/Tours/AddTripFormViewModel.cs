namespace TravelAgent.Web.Areas.Admin.Models.Tours
{
    using System;

    public class AddTripFormViewModel
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Today.AddDays(20);

        public DateTime EndDate { get; set; } = DateTime.Today.AddDays(21);

        public decimal Price { get; set; }

        public int BusSeatsNumber { get; set; }

        public int TourId { get; set; }
    }
}
