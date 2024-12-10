using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClubLibrary.Bookingdata
{
    public class Booking
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public int BoatId { get; set; }

        private static int NextId = 1;


        public Booking(int memberId, int boatId)
        {
            Id = NextId++;
            MemberId = memberId;
            BoatId = boatId;
        }

        public override string ToString()
        {
            return $"Id: {Id}, MemberId: {MemberId}, BoatId {BoatId}";
        }
    }
}
