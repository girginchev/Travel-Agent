namespace TravelAgent.Web.Models.Tours
{
    using System.Collections.Generic;
    using TravelAgent.Services.Tours.Models;

    public class ToursIndexViewModel
    {
        public IEnumerable<ToursListingServiceModel> TopTours { get; set; }

        public IEnumerable<ToursListingServiceModel> Bulgaria { get; set; }

        public IEnumerable<ToursListingServiceModel> Austria { get; set; }

        public IEnumerable<ToursListingServiceModel> Romania { get; set; }

        public IEnumerable<ToursListingServiceModel> Greece { get; set; }

        public IEnumerable<ToursListingServiceModel> Albania { get; set; }

        public IEnumerable<ToursListingServiceModel> Macedonia { get; set; }

        public IEnumerable<ToursListingServiceModel> Croatia { get; set; }

        public IEnumerable<ToursListingServiceModel> Serbia { get; set; }

    }
}
