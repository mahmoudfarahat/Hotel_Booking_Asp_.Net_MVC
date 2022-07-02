using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace HotelBooking.Models
{
    public class Room
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int BedNumber { get; set; }
        public decimal  Size { get; set; }
 
        public byte IsReserved { get; set; }

        public string RoomImage { get; set; }

    }
}