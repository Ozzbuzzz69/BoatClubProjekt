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


        /// <summary>
        /// Checks if Boats contains a key similar to argument.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// If a Boat has the same key as argument is returns true, if not it returns false.
        /// </returns>
        public static Boat? ReadBoat(int id)
        {
            if (Boats.ContainsKey(id))
            {
                return Boats[id];
            }
            return null;
        }

        /// <summary>
        /// Checks if a Boat with same Id as boatId exists, and if not equal null it updates boat.
        /// </summary>
        /// <param name="boatId"></param>
        /// <param name="boat"></param>
        /// <returns>
        /// Returns true if updated, if not updated or Boat is null it returns false.
        /// </returns>
        public static bool UpdateBoat(int boatId, Boat boat) //Den skal nok have en anden return type
        {
            if (ReadBoat(boatId) != null)
            {
                Boats[boatId] = boat;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Function takes an id and an attribute to change and gives it a new value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="attribute"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public static bool UpdateBoatAttribute(int id, string attribute, object newValue)
        {
            //check if boat exists
            if (ReadBoat(id) is Boat boat) 
            {
                //set the property we are looking for
                var property= boat.GetType().GetProperty(attribute);

                //check not null
                if (property == null) { return false; }
                //check it can be written, so it can be changed
                if (!property.CanWrite) { return false; }

                try
                {
                    //set newValue to the type we looked for
                    var newValueType = Convert.ChangeType(newValue, property.PropertyType);
                    //set the value of newValue
                    property.SetValue(boat, newValueType);

                    //Use the newValue to make a new boat
                    UpdateBoat(id, boat);
                    return true;
                }
                //catch in case of something wrong
                catch { return false; }
            }
            return false;
        }


        /// <summary>
        /// Deletes a boat with same Id as argument.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// If a Boat with same Id as argument is deleted it returns true, if not it returns false.
        /// </returns>
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


        public static List<Boat> GetBoats()
        {
            return Boats.Values.ToList();
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