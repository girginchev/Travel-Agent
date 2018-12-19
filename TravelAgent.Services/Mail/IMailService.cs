namespace TravelAgent.Services.Mail
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TravelAgent.Services.Newsletter.Models;

    public interface IMailService
    {
        Task SendEmail(string email, string subject, string message);

        Task SendNewsletter(List<SubscribersServiceModel> subscribers, string subject, string message);

        Task SendReservationEmail(string email, string reservationId);

        Task SendReservationConfirmEmail(string email, string reservationId);
    }
}
