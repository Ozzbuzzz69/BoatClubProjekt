using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClubLibrary.Bookingdata
{
    public class BookingRepo
    {
        public Dictionary<int, Booking> Bookings = new();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        public bool CreateBooking(Booking booking)
        {
            if (booking != null)
            {
                Bookings.TryAdd(booking.Id, booking);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Booking? ReadBooking(int id)
        {
            if (Bookings.TryGetValue(id, out Booking? value))
            {
                return value;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookingid"></param>
        /// <param name="booking"></param>
        /// <returns></returns>
        public Booking? UpdateBooking(int bookingid, Booking booking)
        {
            if (ReadBooking(bookingid) != null)
            {
                Bookings[bookingid] = booking;
                return booking;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteBooking(int id)
        {
            if (ReadBooking(id) != null)
            {
                Bookings.Remove(id);
                return true;
            }
            return false;
        }
    }
}
