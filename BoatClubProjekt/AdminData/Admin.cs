using BoatClubLibrary.BoatData;
using BoatClubLibrary.EventData;
using BoatClubLibrary.MemberData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
        /// </summary>
        #region Boat Management
        public bool CreateBoat(Boat boat)
        {
            return BoatRepo.CreateBoat(boat);
        }
        public Boat? ReadBoat(int id)
        {
            return BoatRepo.ReadBoat(id);
        }
        public bool UpdateBoat(int id, Boat boat)
        {
            return BoatRepo.UpdateBoat(id, boat);
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
        public Member UpdateMember(int memberId, Member member) 
        { 
            return  MemberRepo.UpdateMember(memberId, member); 
        }
        public bool DeleteMember(int memberId) 
        { 
            return MemberRepo.DeleteMember(memberId); 
        }
        #endregion
    }
}
