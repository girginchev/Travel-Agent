namespace TravelAgent.Services.Admin
{
    using System;
    using System.Collections.Generic;
    using TravelAgent.Services.Reservations.Models;
    using TravelAgent.Services.Tours.Models;

    public interface IAdminTourService
    {
        void Create(
            string title,
            byte[] headPicture,
            List<byte[]> tourDayPictures,
            List<string> tourDayTitles,
            List<string> tourDayDescriptions,
            DateTime startDate,
            DateTime endDate,
            decimal price,
            int busSeatsNumber,
            int nights,
            string startingPoint,
            string destination,
            string destinationType,
            string description,
            string usefulInformation,
            List<string> priceIncludes,
            List<string> priceDoesNotIncludes,
            List<string> additionalServicesContents,
            List<decimal> additionalServicesPrices);

        bool EditHeader(int id, byte[] headPicture, string title);

        bool EditТourDay(int id, int tourDayId, byte[] dayPicture, string dayTitle, string dayDescription);

        bool EditUsefulInformation(int id, string content);

        void AddTrip(int tourId, DateTime startDate, DateTime EndDate, decimal price, int busSeats);

        bool EditTrip(int id, DateTime startDate, DateTime endDate, decimal price);

        bool DeleteTrip(int id, int tripId);

        bool EditPriceIncludes(int id, string content);

        bool EditPricePriceDoesNotIncludes(int id, string content);

        void AddAdditionalService(int tourId, string content, decimal price);

        bool EditAdditionalService(int id, int sericeId, string content, decimal price);

        bool DeleteService(int id, int serviceId);

        void SetSeatAvailability(List<int> seatId, List<bool> isReserved, List<int> seatNumbers, int busId, int tripId);

        TourDetailsServiceModel ById(int id);

        BusSeatsListingServiceModel BusSeatsByTripId(int id);

        List<AddAdditionalServicesModel> AddititionalServicesByTripId(int id);

        void ChangeDestinationType(int tourId, TourDestinationTypesServiceModel type);
    }
}
