using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClubLibrary.Bookingdata
{
    public class Booking
    {
        private int Id { get; set; }

        private static int NextId = 1;


        public Booking()
        {
            Id = NextId++;
        }

        public override string ToString()
        {
            return $"id: {Id}";
        }
    }
}
