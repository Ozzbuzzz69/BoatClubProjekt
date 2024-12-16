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
        private static Dictionary<int, Boat> Boats = new Dictionary<int, Boat>();


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
        /// If a Boat has the same key as argument is returns the Boat with the same key as argument, if not it returns null.
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
        public static bool UpdateBoat(int boatId, Boat boat)
        {
            if (ReadBoat(boatId) != null)
            {
                Boats[boatId] = boat;
                return true;
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
            if (ReadBoat(id) != null)
            {
                ReadBoat(id)!.IsRented = true; 
            }
        }


        /// <summary>
        /// Unrents a boat by checking if the Readboat function isn't null and that the property IsRented isn't false.
        /// </summary>
        /// <param name="id"></param>
        public static void UnrentBoat(int id)
        {
            if (ReadBoat(id) != null) 
            { 
                ReadBoat(id)!.IsRented = false;
            }
        }


        /// <summary>
        /// Searches after boats with the same type as argument.
        /// </summary>
        /// <param name="type"></param>
        /// <returns>
        /// Returns a list of all matching boats.
        /// </returns>
        public static List<Boat> SearchBoat(string type)
        {
            List<Boat> MatchingBoats = new List<Boat>();

            foreach (Boat boat in Boats.Values)
            {
                if (boat.Type == type)
                {
                    MatchingBoats.Add(boat);
                }
            }
            return MatchingBoats;
        }


        /// <summary>
        /// Searches after boats with the same bool as argument.
        /// </summary>
        /// <param name="isRented"></param>
        /// <returns>
        /// Returns a list of all matching boats.
        /// </returns>
        public static List<Boat> SearchBoat(bool isRented)
        {
            List<Boat> MatchingBoats = new List<Boat>();

            foreach (Boat boat in Boats.Values)
            {
                if (boat.IsRented == isRented)
                {
                    MatchingBoats.Add(boat);
                }
            }
            return MatchingBoats;
        }
    }
}