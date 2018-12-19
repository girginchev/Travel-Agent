namespace TravelAgent.Services.Reservations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TravelAgent.Services.Reservations.Models.CustomAttributes;

    public class AddReservationServiceModel
    {
        public string Id { get; set; }

        public int TripId { get; set; }

        public string TourTitle { get; set; }

        public DateTime TripStartDate { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EGN]
        [Display(Name = "EGN")]
        public string EGN { get; set; }

        [Phone]
        [Display(Name = "Mobile Phone")]
        public string Phone { get; set; }

        public int BusId { get; set; }

        public List<int> SeatId { get; set; }

        public List<int> SeatNumbers { get; set; }

        public List<bool> IsReserved { get; set; }

        public int ReservedSeatId { get; set; }

        public List<AddAdditionalServicesModel> AdditionalServices { get; set; }

        public decimal BasePrice { get; set; }

        public decimal TotalPrice { get; set; }

        [Display(Name = "First name in cyrilic")]
        public string FirstNameCyrilic { get; set; }

        [Display(Name = "Surname in cyrilic")]
        public string SurNameCyrilic { get; set; }

        [Display(Name = "Last name in cyrilic")]
        public string LastNameCyrilic { get; set; }

        [Display(Name = "First name in latin")]
        public string FirstNameLatin { get; set; }

        [Display(Name = "Surname in latin")]
        public string SurNameLatin { get; set; }

        [Display(Name = "Last name in latin")]
        public string LastNameLatin { get; set; }

        [Display(Name = "Passport number")]
        public string PasportNumber { get; set; }

        [Display(Name = "Date of issue")]
        public string PasportDateOfIssue { get; set; }

        [Display(Name = "Valid till")]
        public string PasportValidityDate { get; set; }

        [Display(Name = "Personal document number")]
        public string IdCard { get; set; }

        [Display(Name = "Date of issue")]
        public string IdCardDateOfIssue { get; set; }

        [Display(Name = "Valid till")]
        public string IdCardValidityDate { get; set; }

        public string Address { get; set; }

        public bool GDPRConfirm { get; set; }

        public bool GDPRRead { get; set; }
    }
}
