namespace TravelAgent.Services.Reservations
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TravelAgent.Services.Reservations.Models;

    public interface IReservationService
    {
        Task CreateReservation(
                    string id,
                    int tripId,
                    string egn,
                    string email,
                    string password,
                    string phone,
                    int reservedSeatId,
                    List<AddAdditionalServicesModel> selectedServices,
                    decimal totalPrice,
                    string tourTitle,
                    string firstNameCyrilic,
                    string surNameCyrilic,
                    string lastNameCyrilic,
                    string firstNameLatin,
                    string surNameLatin,
                    string lastNameLatin,
                    string pasportNumber,
                    DateTime pasportDateOfIssue,
                    DateTime pasportValidityDate,
                    string idCard,
                    DateTime idCardDateOfIssue,
                    DateTime idCardValidityDate,
                    string address,
                    bool gdprConfirm,
                    bool gdprRead);

        AddReservationServiceModel BusSeatsByTripId(int id);

        List<AddAdditionalServicesModel> AdditionalServicesByTripId(int id); 

        int GetFirstFreeSeat(int tripId); 

        string GetTourName(int id);

        decimal GetBasePrice(int id);

        DateTime GetStartDate(int id);

        List<ReservationsListingServiceModel> GetAllReservationsByTripId(int tripId);

        ReservationsDetailsServiceModel GetReservationDetailsByTripId(string resId);

        List<ReservationsDetailsServiceModel> GetAllReservationsByTripIdFullDetails(int tripId);

        bool ConfirmReservation(bool IsFinalized, string id);

        string GetEmailByReservationId(string id);

        ReservationShortDetailsServiceModel FindReservation(string reservationId);
    }
}
