namespace TravelAgent.Services.Newsletter
{
    using System.Collections.Generic;
    using TravelAgent.Services.Newsletter.Models;

    public interface INewsletterService
    {
        SubscribersServiceModel Create(string email);

        bool Add(string email, string key);

        bool UnSubscribe(string email, string key);

        List<SubscribersServiceModel> GetAllScubscribersEmails();
    }
}
