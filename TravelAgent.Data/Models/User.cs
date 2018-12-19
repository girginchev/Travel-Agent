namespace TravelAgent.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public string FirstNameCyrilic { get; set; }

        public string SurNameCyrilic { get; set; }

        public string LastNameCyrilic { get; set; }

        public string FirstNameLatin { get; set; }

        public string SurNameLatin { get; set; }

        public string LastNameLatin { get; set; }

        public string EGN { get; set; }

        public string PasportNumber { get; set; }

        public DateTime PasportDateOfIssue { get; set; }

        public DateTime PasportValidityDate { get; set; }

        public string IdCard { get; set; }

        public DateTime IdCardDateOfIssue { get; set; }

        public DateTime IdCardValidityDate { get; set; }

        public string Adress { get; set; }

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
