using System;
using System.Collections.Generic;
using System.Linq;
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
            if (Boats.ContainsKey(id))
            {
                return Boats[id];
            }
            return null;
        }

        public Boat? UpdateBoat(int boatId, Boat boat)
        {
            if (Boats.ContainsKey(boatId))
            {
                Boats[boatId] = boat;
                return boat;
            }
            return null;
        }

        public bool DeleteBoat(int id)
        {
            if (Boats.ContainsKey(id))
            {
                Boats.Remove(id);
                return true;
            }
            return false;
        }

        public void SearchBoat()
        {
            // tilføj kode
        }

        public void ReadAllBoats()
        {
            foreach (Boat b in Boats.Values)
            {
                Console.WriteLine(b);
            }
        }

        public static IEnumerable<Boat> GetBoats()
        {
            return Boats.Values;
        }
    }
}