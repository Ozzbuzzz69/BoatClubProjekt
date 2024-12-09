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
        /// Creates a new booking, and checks if the booking is valid and != null, if so the booking is 
        /// added to the dictionary Bookings via the id. If the booking is not valid it returns null
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
        /// Checks if the dictionary Bookings has the given value of id, if so it returns the value,
        /// otherwise it returns null
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
        /// Checks if the ReadBooking method returned a value from the given id key, if so update the value in the given key
        /// to a new value and return it. If ReadBooking returned null, return null.
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
        /// Checks if the ReadBooking method returned a value from the given id key, if so remove the id and value from 
        /// dictionary Bookings. If ReadBooking returned null, return false.
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
