using BoatClubLibrary.BlogData;
using BoatClubLibrary.Bookingdata;
using BoatClubLibrary.MemberData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BoatClubLibrary.BoatData
{
    public static class BoatRepo
    {
        private static readonly Dictionary<int, Boat> Boats = new Dictionary<int, Boat>();

        public static bool CreateBoat(Boat boat)
        {
            if (boat != null)
            {
                Boats.TryAdd(boat.Id, boat);
                return true;
            }
            return false;
        }

        public static Boat? ReadBoat(int id)
        {
            if (Boats.ContainsKey(id))
            {
                return Boats[id];
            }
            return null;
        }

        public static Boat? UpdateBoat(int boatId, Boat boat) //Den skal nok have en anden return type
        {
            if (ReadBoat(boatId) != null)
            {
                Boats[boatId] = boat;
                return boat;
            }
            return null;
        }

        public static bool DeleteBoat(int id)
        {
            if (ReadBoat(id) != null)
            {
                Boats.Remove(id);
                return true;
            }
            return false;
        }
        
        /* Remove, as it is too hard to explain
        //Takes a criteria and finds the first boat with any criteria of that value
        public static Boat? SearchBoat(object criteria)
        {
            if (criteria == null) return null;

            foreach (KeyValuePair<int, Boat> boat in Boats)
            {
                foreach (PropertyInfo property in boat.Value.GetType().GetProperties())
                {
                    // Get the value of the property for the current boat
                    object? propertyValue = property.GetValue(boat.Value);

                    // Check if the property value matches the criteria
                    if (propertyValue != null && propertyValue.Equals(criteria))
                    {
                        return boat.Value; // Found a match
                    }
                }
            }

            return null; // No match found
        }
        */

        public static void ReadAllBoats()
        {
            foreach (KeyValuePair<int, Boat> boat in Boats)
            {
                Console.WriteLine(boat); //Fjern console.writeline
            }
        }

        public static IEnumerable<Boat> GetBoats()
        {
            return Boats.Values;
        }

        public static void RentBoat(int id)
        {
            if (ReadBoat(id) != null) { ReadBoat(id)!.IsRented = true; }
        }

        public static void UnrentBoat(int id)
        {
            if (ReadBoat(id) != null) { ReadBoat(id)!.IsRented = false;}
        }
    }
}