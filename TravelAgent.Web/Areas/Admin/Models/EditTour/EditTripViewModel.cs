namespace TravelAgent.Web.Areas.Admin.Models.EditTour
{
    using System;

    public class EditTripViewModel
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public int TourId { get; set; }
    }
}
