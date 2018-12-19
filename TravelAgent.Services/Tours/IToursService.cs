namespace TravelAgent.Services.Tours
{
    using System.Collections.Generic;
    using TravelAgent.Services.Tours.Models;

    public interface IToursService
    {
        IEnumerable<ToursListingServiceModel> All(int page = 1);

        IEnumerable<ToursListingServiceModel> Bulgaria(int page = 1);

        IEnumerable<ToursListingServiceModel> Abroad(int page = 1);

        IEnumerable<ToursListingServiceModel> ByMonth(int month, int page);

        IEnumerable<ToursListingServiceModel> BySearchTerm(string searchTerm, int page);

        IEnumerable<ToursListingServiceModel> ByPriceRange(decimal priceFrom, decimal priceTo, int page);

        IEnumerable<ToursListingServiceModel> TopAlbania();

        IEnumerable<ToursListingServiceModel> TopBulgaria();

        IEnumerable<ToursListingServiceModel> TopCroatia();

        IEnumerable<ToursListingServiceModel> TopGreece();

        IEnumerable<ToursListingServiceModel> TopMacedonia();

        IEnumerable<ToursListingServiceModel> TopRomania();

        IEnumerable<ToursListingServiceModel> TopAustria();

        IEnumerable<ToursListingServiceModel> TopSerbia();

        IEnumerable<ToursListingServiceModel> TopTours();


        int Total();

        int TotalBulgaria();

        int TotalAbroad();

        int TotalForMonth( int month);

        int TotalBySearchTerm(string searchTerm);

        int TotalByPriceRange(decimal priceFrom, decimal priceTo);

        TourDetailsServiceModel ById(int id);
    }
}
