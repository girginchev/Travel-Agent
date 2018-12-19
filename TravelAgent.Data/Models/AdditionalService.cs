using System.Collections.Generic;

namespace TravelAgent.Data.Models
{
    public class AdditionalService
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public decimal Price { get; set; }

        public int TourId { get; set; }
        public Tour Tour { get; set; }
    }
}
