using BoatClubLibrary.Bookingdata;
using BoatClubLibrary.MemberData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BoatClubLibrary.BoatData
{
    public class BoatRepo
    {
        public Dictionary<int, Boat> Boats = new Dictionary<int, Boat>();

        public bool CreateBoat(Boat boat)
        {
            if (boat != null)
            {
                Boats.TryAdd(boat.Id, boat);
                return true;
            }
            return false;
        }

        public Boat? ReadBoat(int id)
        {
            if (Boats.TryGetValue(id, out Boat? value))
            {
                return value;
            }
            return null;
        }

        public Boat? UpdateBoat(int boatId, Boat boat)
        {
            if (ReadBoat(boatId) != null)
            {
                Boats[boatId] = boat;
                return boat;
            }
            return null;
        }

        public bool DeleteBoat(int id)
        {
            if (ReadBoat(id) != null)
            {
                Boats.Remove(id);
                return true;
            }
            return false;
        }
        
        //Takes a criteria and finds the first boat with any criteria of that value
        public Boat? SearchBoat(object criteria)
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


        public void ReadAllBoats()
        {
            foreach (KeyValuePair<int, Boat> boat in Boats)
            {
                Console.WriteLine(boat);
            }
        }

        public IEnumerable<Boat> GetBoats()
        {
            return Boats.Values;
        }
    }
}