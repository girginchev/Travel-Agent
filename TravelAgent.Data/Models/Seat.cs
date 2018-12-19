namespace TravelAgent.Data.Models
{
    public class Seat
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public bool IsReserved { get; set; }

        public int BusId { get; set; }
        public Bus Bus { get; set; }
    }
}
