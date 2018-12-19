namespace TravelAgent.Data.Models
{
    using System.Collections.Generic;
    using TravelAgent.Data.Models.Enums;

    public abstract class Excursion
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public byte[] HeaderImage { get; set; }
        
        public string StartingPoint { get; set; }

        public string Destination { get; set; }

        public string Description { get; set; }

        public string PriceIncludes { get; set; }
        
        public string PriceDoesNotIncludes { get; set; }

        public string UsefulInformation { get; set; }

        public int Nights { get; set; }

        public DestinationType DestinationType { get; set; }

        public List<Day> TourDays { get; set; } = new List<Day>();

        public List<AdditionalService> AdditionalServices { get; set; } = new List<AdditionalService>();

        public List<Trip> Trips { get; set; } = new List<Trip>();
    }
}
