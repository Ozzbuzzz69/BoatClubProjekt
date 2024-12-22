using BoatClubLibrary.BlogData;
using BoatClubLibrary.BoatData;
using BoatClubLibrary.EventData;
using BoatClubLibrary.MemberData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BoatClubLibrary.AdminData
{
    public class Admin : Person
    {
        private static int NextId = 0;

        public Admin(string name, string address, string email, string phoneNumber) : base(name, address, email, phoneNumber)
        {
            Id = ++NextId;
        }
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Address {Address}, Email: {Email}, Phonenumber: {PhoneNumber}";
        }

        /// <summary>
        /// The boat related functionalites admin has access to
        /// </summary>        #region Boat Management
        public bool CreateBoat(Boat boat)
        {
            return BoatRepo.CreateBoat(boat);
        }
        public Boat? ReadBoat(int id)
        {
            return BoatRepo.ReadBoat(id);
        }
        public bool UpdateBoat(int id, double rentalPrice, string type, string model, string name, int regNumber, int horsePower, int knots,
            double height, double length, double width, bool isRented, string log)
        {
            return BoatRepo.UpdateBoat(id, rentalPrice, type, model, name, regNumber, horsePower, knots,
            height, length, width, isRented, log);
        }

        public bool DeleteBoat(int id)
        {
            return BoatRepo.DeleteBoat(id);
        }
        public List<Boat> ReadAllBoats() 
        { 
            return BoatRepo.ReadAllBoats(); 
        }
        public void RentBoat(int id) 
        { 
            BoatRepo.RentBoat(id); 
        }
        public void UnrentBoat(int id) 
        { 
            BoatRepo.UnrentBoat(id); 
        }


        #endregion

        /// <summary>
        /// The member related functionalites admin has access to
        /// </summary>
        #region Member Management
        public void CreateMember(Member member) 
        { 
            MemberRepo.CreateMember(member); 
        }
        public Member? ReadMember(int memberId) 
        { 
            return MemberRepo.ReadMember(memberId);
        }
        public List<Member>? ReadMemberList() 
        { 
            return MemberRepo.ReadMemberList(); 
        }
        //public Member UpdateMember(int memberId, string name, string address, string email, string phoneNumber, MembershipType membershipType,
        //    string birthday, bool isRenting) 
        //{ 
        //    return  MemberRepo.UpdateMember(memberId, name, address, email, phoneNumber, membershipType,
        //    birthday, isRenting); 
        //}
        public bool DeleteMember(int memberId) 
        { 
            return MemberRepo.DeleteMember(memberId); 
        }
        #endregion
    }
}
