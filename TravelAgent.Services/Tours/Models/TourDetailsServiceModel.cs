namespace TravelAgent.Services.Tours.Models
{
    using System.Collections.Generic;
    using TravelAgent.Data.Migrations;

    public class TourDetailsServiceModel
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

        public int Duration { get; set; }

        public List<TourDayDatailsServiceModel> TourDays { get; set; } = new List<TourDayDatailsServiceModel>();

        public List<TripServiceModel> Trips { get; set; } = new List<TripServiceModel>();

        public List<TourAdditionalServicesServiceModel> AdditionalSevices { get; set; } = new List<TourAdditionalServicesServiceModel>();

        public TourDestinationTypesServiceModel DestinationType { get; set; }
    }
}
