namespace TravelAgent.Services.Tours.Models
{
    public class ToursListingServiceModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public byte[] HeaderImage { get; set; }

        public string Destination { get; set; }

        public decimal LowestPrice { get; set; }

        public int TourDaysCount { get; set; }
    }
}
