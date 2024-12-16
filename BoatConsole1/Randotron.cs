using BoatClubLibrary;
using BoatClubLibrary.MemberData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatConsole1
{
    public static class Randotron
    {
        public static string Generate(string command)
        {
            command = command.ToLower();
            switch (command) 
            {
                case "person": return GenerateName();
                case "boat": return GenerateBoat();
                case "description": return GenerateDescription();
                case "birthday": return GenerateBirthday();
                case "address": return GenerateAddress();
                case "email": return GenerateEmail();
                case "phone number": return GeneratePhoneNumber();

                default: return string.Empty;
            }
        }
        private static string GenerateName() 
        {
            Random random = new Random();
            return Names[random.Next(Names.Count())];
        }
        private static string GenerateBoat()
        {
            Random random = new Random();
            return BoatNames[random.Next(BoatNames.Count())];
        }
        private static string GenerateDescription()
        {
            Random random = new Random();
            return Descriptions[random.Next(Descriptions.Count())];
        }
        private static string GenerateBirthday()
        {
            Random random = new Random();
            return Birthdays[random.Next(Birthdays.Count())];
        }
        private static string GenerateAddress()
        {
            Random random = new Random();
            return Address[random.Next(Address.Count())];
        }
        private static string GenerateEmail()
        {
            Random random = new Random();
            return Emails[random.Next(Emails.Count())];
        }
        private static string GeneratePhoneNumber()
        {
            Random random = new();
            return PhoneNumbers[random.Next(PhoneNumbers.Count())];
        }
        public static (double Price, string Type, string Model, string Name, int RegNumber, int HorsePower,
                       int Knots, double Height, double Length, double Width, bool isRented, string Log) FullBoat()
        {
            Random random = new();

            return (
                Price: Price[random.Next(Price.Count())],
                Type: Type[random.Next(Type.Count())],
                Model: Model[random.Next(Model.Count())],
                Name: GenerateBoat(),
                RegNumber: RegNumber[random.Next(RegNumber.Count())],
                HorsePower: HorsePower[random.Next(HorsePower.Count())],
                Knots: Knots[random.Next(Knots.Count())],
                Height: Height[random.Next(Height.Count())],
                Length: Length[random.Next(Length.Count())],
                Width: Width[random.Next(Width.Count())],
                isRented: false, //fixed value
                Log: Log[random.Next(Log.Count())]
            );
        }

        public static (string Name, string Address, string Email, string PhoneNumber, MembershipType MembershipType, string Birthday, bool IsRenting) FullMember()
        {
            Random random = new();

            return (
                Name: Generate("person"),
                Address: Generate("address"),
                Email: Generate("email"),
                PhoneNumber: Generate("phone number"),
                MembershipType: 0,
                Birthday: Generate("birthday"),
                IsRenting: false // Default inactive status
            )!;
        }


        #region Storage
        private static List<string> Names = ["Steve", "Jeff", "Mikkel", "Henrik", "Jesper", "Carl", "Jessica", "Caroline", "Bella"];
        private static List<string> BoatNames = ["Deez Knots", "Leaky Hullz", "Santa Maria", "Sloopy Joe", "Sailor Swift", "Flying Clutchman", "OnlyFins", "Pier Pressure"];
        private static List<string> Descriptions = ["A fun night at sea", "Not a hitjob", "I spent thirty years programming, and all I got was this boat", "Camel hunting at sea", "Legal drug smuggling"];
        private static List<string> Birthdays = ["9/11", "19/12", "7/11", "31/2", "Tomorrow", "25/12", "1/1"];
        private static List<string> Address = ["Big Beaver Road", "Throwita Way", "Zzyzyx Road", "West Bacon Street", "This Way", "That Way"];
        private static List<string> Emails = ["Redneckvaper22@gmail.com", "iselldrugs@PET.dk", "MikeHawk@outlook.com", "shinji@evangelion.jp", "radioguy@podcast.fm"];
        private static List<string> PhoneNumbers = ["53219260", "72243906", "32427125", "08652074", "77006422", "69396869"];

        #region Boatstuff
        private static List<double> Price = [7, 20, 1000, 225, 2225, 100.99, 99.100, 10, 100, 10000];
        private static List<double> Height = [1.5, 2.75, 10, 10.66, 8, 7, 3];
        private static List<double> Length = Height;
        private static List<double> Width = Height;
        private static List<string> Type = ["Speed", "Canoe", "Sloop", "Galleon", "Yacht", "lifeboat", "Sailboat", "Jetski"];
        private static List<string> Model = ["A26", "W-XX", "ZZZ", "UNE", "steve", "HMRN"];
        private static List<string> Log = ["its aight.", "Totally messed up", "Someone let Michael aboard and now it is slowly sinking", "'Write Log here", "You can't spell Torpedo without the pedo. Therefore this vessel is up for decomission"];
        private static List<int> RegNumber = [7, 201, 22, 8345, 374, 4831, 452, 48412, 112, 991];
        private static List<int> HorsePower = [1, 2, 3, 10, 100, 1000, 10000, 225, 42, 98, 65];
        private static List<int> Knots = [1, 2, 10, 17, 12, 5, 20, 30, 36, 50, 5, 8];
        #endregion
        #endregion
    }
}
