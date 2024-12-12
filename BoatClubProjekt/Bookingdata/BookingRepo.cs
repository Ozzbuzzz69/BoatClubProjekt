using BoatClubLibrary.MemberData;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// If booking is updated it returns Booking, if there is no booking with bookingid it returns null.
        /// </returns>
        public static bool UpdateBooking(int bookingid, Booking booking)
        {
            if (ReadBooking(bookingid) != null)
            {
                Bookings[bookingid] = booking;
                return true;
            }
            return false;
        }
        public static bool UpdateBookingAttribute(int id, string attribute, object newValue)
        {
            //check if booking exists
            if (ReadBooking(id) is Booking booking)
            {
                //set the property we are looking for
                var property = booking.GetType().GetProperty(attribute);

                //check not null
                if (property == null) { return false; }
                //check it can be written, so it can be changed
                if (!property.CanWrite) { return false; }

                try
                {
                    //set newValue to the type we looked for
                    var newValueType = Convert.ChangeType(newValue, property.PropertyType);
                    //set the value of newValue
                    property.SetValue(booking, newValueType);

                    //Use the newValue to make a new booking
                    UpdateBooking(id, booking);
                    return true;
                }
                //catch in case of something wrong
                catch { return false; }
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
    }
}
