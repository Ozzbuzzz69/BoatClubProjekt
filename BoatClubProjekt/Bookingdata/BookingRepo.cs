using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClubLibrary.Bookingdata
{
    public class BookingRepo
    {
        public static Dictionary<int, Booking> Bookings = new Dictionary<int, Booking>();

        public bool AddBooking(Booking booking)
        {
            if (booking != null)
            {
                Bookings.TryAdd(booking.Id, booking);
                return true;
            }
            return false;
        }
        public Booking? ReadBooking(int id)
        {
            if (Bookings.ContainsKey(id))
            {
                return Bookings[id];
            }
            return null;
        }
        public Booking Update(int bookingid,  Booking booking)
        {
            if (Bookings.ContainsKey(bookingid))
            {
                Bookings[bookingid] = booking;
            }
            return booking;
        }
        public bool DeleteBooking(int id)
        {
            if (Bookings.ContainsKey(id))
            {
                Bookings.Remove(id);
                return true;
            }
            return false;
        }
    }
}
