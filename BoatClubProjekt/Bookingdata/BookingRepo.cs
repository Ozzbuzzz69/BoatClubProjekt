using BoatClubLibrary.BoatData;
using BoatClubLibrary.MemberData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BoatClubLibrary.Bookingdata
{
    public static class BookingRepo
    {
        public static Dictionary<int, Booking> Bookings = new();

        /// <summary>
        /// Creates a new booking, and checks if the booking is valid and != null, if so the booking is 
        /// added to the dictionary Bookings via the id.
        /// </summary>
        /// <param name="booking"></param>
        /// <returns>
        /// If the booking is created it returns true, if the booking is not valid it returns null.
        /// </returns>
        public static bool CreateBooking(Booking booking)
        {
            if (booking != null)
            {
                Bookings.TryAdd(booking.Id, booking);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if the dictionary Bookings has the given value of id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// If so it returns the value, otherwise it returns null.
        /// </returns>
        public static Booking? ReadBooking(int id)
        {
            if (Bookings.ContainsKey(id))
            {
                return Bookings[id];
            }
            return null;
        }

        /// <summary>
        /// Checks if the ReadBooking method returned a value from the given id key, if so update the value in the given key
        /// to a new value.
        /// </summary>
        /// <param name="bookingid"></param>
        /// <param name="booking"></param>
        /// <returns>
        /// If booking is updated it returns true, if there is no booking with bookingid, and therfore nothing updated, it returns false.
        /// </returns>
        public static bool UpdateBooking(int bookingId, int memberId, int boatId)
        {
            if (ReadBooking(bookingId) != null)
            {
                Bookings[bookingId].MemberId = memberId;
                Bookings[bookingId].BoatId = boatId;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if the ReadBooking method returned a value from the given id key, if so remove the id and value from 
        /// dictionary Bookings.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Returns true if booking with specifik id is deleted. 
        /// If Bookings does not have a booking with specific id and is not deleted it returns false.
        /// </returns>
        public static bool DeleteBooking(int id)
        {
            if (ReadBooking(id) != null)
            {
                Bookings.Remove(id);
                return true;
            }
            return false;
        }


        /// <summary>
        /// Reads all the bookings from Bookings.
        /// </summary>
        /// <returns>
        /// Returns a list of Booking values.
        /// </returns>
        public static List<Booking> ReadAllBookings()
        {
            return Bookings.Values.ToList();
        }
    }
}
