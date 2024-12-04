using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClubLibrary.BoatData
{
    public class Harbour
    {
        public static Dictionary<int, Boat> Boats = new Dictionary<int, Boat>();

        public bool CreateBoat(double rentalPrice, string type, string model, string name, int regNumber, int horsePower, int knots, double height, double length, double width, bool isRented)
        {
            Boat boat = new Boat(rentalPrice,type,model,name,regNumber,horsePower,knots,height,length,width,isRented); 
            Boats.TryAdd(boat.Id,boat);
            return true;
        }

        public bool AddBoat(Boat boat)
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

        public bool UpdateBoat(int id, double rentalPrice, string type, string model, string name, 
            int regNumber, int horsePower, int knots, double height, double length, double width, bool isRented)
        {
            if (Boats.ContainsKey(id))
            {
                Boats[id].RentalPrice = rentalPrice;
                Boats[id].Type = type;
                Boats[id].Model = model;
                Boats[id].Name = name;
                Boats[id].RegNumber = regNumber;
                Boats[id].HorsePower = horsePower;
                Boats[id].Knots = knots;
                Boats[id].Height = height;
                Boats[id].Length = length;
                Boats[id].Width = width;
                Boats[id].IsRented = isRented;
                return true;
            }
            return false;
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

        public static IEnumerable<Boat> GetBoats()
        {
            return Boats.Values;
        }
    }
}