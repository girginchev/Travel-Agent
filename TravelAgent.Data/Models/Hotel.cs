namespace TravelAgent.Data.Models
{
    using System.Collections.Generic;

    public class Hotel
    {
        public int Id { get; set; }

        public string HotelDescription { get; set; }

        public string HotelLink { get; set; }

        public List<HotelPicture> HotelPictures { get; set; } = new List<HotelPicture>();
    }
}
