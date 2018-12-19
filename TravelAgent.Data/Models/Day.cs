namespace TravelAgent.Data.Models
{
    public class Day
    {
        public int Id { get; set; }

        public string DayTitle { get; set; }

        public string DayDescription { get; set; }

        public byte[] DayPicture { get; set; }

        public int TourId { get; set; }
        public Tour Tour { get; set; }
    }
}
