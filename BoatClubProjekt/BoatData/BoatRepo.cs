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


        /// <summary>
        /// Takes the parameter boat, and checks if the boat object isn't null. If the object is created correct
        /// its added to the dictionary Boats.
        /// </summary>
        /// <param name="boat"></param>
        /// <returns>
        /// If the boat is added to the dictionary Boats it returns true, if not it returns false
        /// </returns>
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

        /// <summary>
        /// Reads all the boats in Boats 
        /// </summary>
        /// <returns>
        /// Returns the boats values in a list of boats
        /// </returns>
        public static List<Boat> ReadAllBoats()
        {
            return Boats.Values.ToList();
        }

        /// <summary>
        /// Rents a boat by checking if the Readboat function isn't null and that the property IsRented isn't true.
        /// </summary>
        /// <param name="id"></param>
        public static void RentBoat(int id)
        {
            if (ReadBoat(id) != null) { ReadBoat(id)!.IsRented = true; }
        }


        /// <summary>
        /// Unrents a boat by checking if the Readboat function isn't null and that the property IsRented isn't false.
        /// </summary>
        /// <param name="id"></param>
        public static void UnrentBoat(int id)
        {
            if (ReadBoat(id) != null) { ReadBoat(id)!.IsRented = false;}
        }
        /// <summary>
        /// Function to take in the name of an attribute and a value for it and then find the
        /// first object which matches the search.
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static Boat? SearchBoat(string attribute, object Value)
        {
            if (Boats.Count > 0)
            {
                foreach (KeyValuePair<int, Boat> boat in Boats)
                {
                    //set the property we are looking for
                    var property = boat.Value.GetType().GetProperty(attribute.ToString());

                    /* Skal nok slettes
                    //set Value to the type we looked for
                    var ValueType = Convert.ChangeType(Value, property.PropertyType);
                    */

                    //check not null
                    if (property == null) { continue; }

                    //go through each property to check its type and value for comparison with the search
                    foreach (PropertyInfo bookingProperty in boat.Value.GetType().GetProperties())
                    {
                        if (bookingProperty.PropertyType == property.PropertyType)
                        {
                            //return correct value
                            if (bookingProperty.GetValue(boat) == Value) return boat.Value;
                        }
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// Function to give the name of an attribute and a value for it, to then get
        /// every object of matching the criteria
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static List<Boat> FilterBoats(string attribute, object Value)
        {
            List<Boat> list = new();

            if (Boats.Count > 0)
            {
                foreach (KeyValuePair<int, Boat> boat in Boats)
                {
                    //set the property we are looking for
                    var property = boat.Value.GetType().GetProperty(attribute.ToString());

                    /* Skal nok slettes
                    //set Value to the type we looked for
                    var ValueType = Convert.ChangeType(Value, property.PropertyType);
                    */

                    //check not null
                    if (property == null) { continue; }

                    //go through each property to check its type and value for comparison with the search
                    foreach (PropertyInfo bookingProperty in boat.Value.GetType().GetProperties())
                    {
                        if (bookingProperty.PropertyType == property.PropertyType)
                        {
                            //add correct value to list
                            if (bookingProperty.GetValue(boat) == Value) list.Add(boat.Value);
                        }
                    }
                }
            }
            //return finished list
            return list;
        }
    }
}