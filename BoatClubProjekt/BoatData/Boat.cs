using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClubLibrary.BoatData
{
    public class Boat
    {
        public int Id { get; set; }
        public double RentalPrice { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public int RegNumber { get; set; }
        public int HorsePower { get; set; }
        public int Knots { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public bool IsRented { get; set; }
        public string Log {  get; set; }
        private static int NextId = 1;

        public Boat() 
        {
            Id = NextId++;
        }
        public Boat(double rentalPrice, string type, string model, string name, int regNumber, int horsePower, int knots, 
            double height, double length, double width, bool isRented, string log)
        {
            Id = NextId++;
            RentalPrice = rentalPrice;
            Type = type;
            Model = model;
            Name = name;
            RegNumber = regNumber;
            HorsePower = horsePower;
            Knots = knots;
            Height = height;
            Length = length;
            Width = width;
            IsRented = isRented;
            Log = log;
        }
        public override string ToString()
        {
            return $"id: {Id}, rentalprice: {RentalPrice}, type: {Type}, model: {Model}, name: {Name}, regnumber: {RegNumber}, " +
                $"horsepower: {HorsePower}, knots: {Knots}, height: {Height}, length: {Length}, width: {Width}, isrented: {IsRented}, Log {Log}";
        }

    }
}
