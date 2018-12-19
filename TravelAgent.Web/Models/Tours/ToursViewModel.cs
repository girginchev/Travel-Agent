namespace TravelAgent.Web.Models.Tours
{
    using System;
    using System.Collections.Generic;
    using TravelAgent.Services;
    using TravelAgent.Services.Tours.Models;

    public class ToursViewModel
    {
        public IEnumerable<ToursListingServiceModel> Tours { get; set; }

        public int TotalTours { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalTours / ServiceConstants.ToursPageSize);

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage
            => this.CurrentPage == this.TotalPages
                ? this.TotalPages
                : this.CurrentPage + 1;
    }
}
