namespace TravelAgent.Services.Newsletter.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TravelAgent.Data;
    using TravelAgent.Data.Models;
    using TravelAgent.Services.Newsletter.Models;
    
    public class NewsletterService : INewsletterService
    {
        private readonly TravelAgentDbContext db;

        public NewsletterService(TravelAgentDbContext db)
        {
            this.db = db;
        }

        public SubscribersServiceModel Create(string email)
        => new SubscribersServiceModel()
        {
            Id = Guid.NewGuid().ToString(),
            Email = email
        };

        public bool Add(string email, string key)
        {
            if (db.Subscribers.Any(s => s.Email == email))
            {
                return false;
            }
            db.Subscribers.Add(new Subscriber
            {
                Id = key,
                Email = email
            });

            db.SaveChanges();
            return true;
        }

        public bool UnSubscribe(string email, string key)
        {
            var subscriber = db.Subscribers.FirstOrDefault(s => s.Email == email && s.Id == key);
            if (subscriber == null)
            {
                return false;
            }
            db.Subscribers.Remove(subscriber);
            db.SaveChanges();
            return true;
        }

        public List<SubscribersServiceModel> GetAllScubscribersEmails()
        {
            return db.Subscribers.Select(s => new SubscribersServiceModel()
            {
                Id = s.Id,
                Email = s.Email,
            }).ToList();
        }
    }
}
