namespace TravelAgent.Web.Areas.Admin.Models.Tours
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AddToursFormViewModel
    {
        public string Title { get; set; }

        public byte[] HeaderImage { get; set; }

        public List<byte[]> TourDayPictures { get; set; } = new List<byte[]>();

        public List<string> TourDayTitles { get; set; }

        public List<string> TourDayDescriptions { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Today.AddDays(20);

        public DateTime EndDate { get; set; } = DateTime.Today.AddDays(21);

        public decimal Price { get; set; }

        public int BusSeats { get; set; }

        public int Nights { get; set; }

        public string StartingPoint { get; set; }

        public string Destination { get; set; }

        public DestinationTypeEnum DestinationType { get; set; }

        public string Description { get; set; }

        public List<string> PriceIncludes { get; set; } = new List<string>();

        public List<string> PriceDoesNotIncludes { get; set; } = new List<string>();

        public string UsefulInformation { get; set; }

        public List<string> AdditionalServicesContents { get; set; } = new List<string>();

        public List<decimal> AdditionalSerivicesPrices { get; set; } = new List<decimal>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.StartDate < DateTime.UtcNow)
            {
                yield return new ValidationResult("Start date should be in the future.");
            }

            if (this.StartDate > this.EndDate)
            {
                yield return new ValidationResult("Start date should be before end date.");
            }
        }
    }
}
