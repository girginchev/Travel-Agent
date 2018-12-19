namespace TravelAgent.Services.Tours.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class BusServiceModel
    {
        public int Id { get; set; }

        public List<SeatServiceModel> Seats { get; set; } = new List<SeatServiceModel>();
    }


}
