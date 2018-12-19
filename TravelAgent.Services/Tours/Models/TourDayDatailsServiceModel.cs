namespace TravelAgent.Services.Tours.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TourDayDatailsServiceModel
    {
        public int Id { get; set; }

        public string DayTitle { get; set; }

        public string DayDescription { get; set; }

        public byte[] DayPicture { get; set; }
    }
}
