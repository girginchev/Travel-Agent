namespace TravelAgent.Data.Models
{
    using System.Collections.Generic;

    public class Holiday : Excursion
    {
        public List<Hotel> Hotels { get; set; } = new List<Hotel>();
    }
}
