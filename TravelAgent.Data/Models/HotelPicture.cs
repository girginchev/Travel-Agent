using System;
using System.Collections.Generic;
using System.Text;

namespace TravelAgent.Data.Models
{
    public class HotelPicture
    {
        public int Id { get; set; }

        public byte[] Picture { get; set; }

        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
