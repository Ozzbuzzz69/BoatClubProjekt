using BoatClubLibrary.BoatData;
using BoatClubLibrary.Bookingdata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClubLibrary.MemberData
{
    public static class MemberRepo
    {
        private static readonly Dictionary<int, Member> MemberList = new Dictionary<int, Member>();
        //public List<Boat> _bookableBoats;

        //public MemberRepo()
        //{
        //    _bookableBoats = BoatRepo.GetBoats().ToList();  
        //}

        /// <summary>
        /// Adds a member to Dictionary if the Dictionary does not already contain a member with same Id.
        /// </summary>
        /// <param name="member"></param>
        public static void CreateMember(Member member)
        {
            MemberList.TryAdd(member.Id, member);
        }

        /// <summary>
        /// Reads a member with given Id as argument.
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns>
        /// Returns Member if the Dictionary contains a Member with given Id, if not it returns null.
        /// </returns>
        public static Member? ReadMember(int memberId)
        {
            if (MemberList.ContainsKey(memberId))
            {
                return MemberList[memberId];
            }
            return null;
        }

        public static List<Member>? ReadMemberList()
        {
            if (MemberList != null)
            {
                return MemberList.Values.ToList();
            }
            return null;
        }
                
        public static void UpdateForRazor(Member member)
        {
            if (ReadMember(member.Id) != null)
            {
                MemberList[member.Id] = member;
            }
        }

        public static Member UpdateMember(int memberId, Member member)
        {
            if (ReadMember(memberId) != null)
            {
                MemberList[memberId] = member;
            }
            return member;
        }

        /// <summary>
        /// Deletes a Member with same Id as argument from Dictionary. 
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns>
        /// If a Member has the same Id as argument and the Member has been removed it returns true.
        /// If no member has the Id it returns false.
        /// </returns>
        public static bool DeleteMember(int memberId)
        {
            if (ReadMember(memberId) != null)
            {
                MemberList.Remove(memberId);
                return true;
            }
            return false;
        }
        public static void DeteleForRazor(Member member)
        {
            if (ReadMember(member.Id) != null)
            {
                MemberList.Remove(member.Id);
            }
        }



        public static List<Member> GetMembers()
        {
            return MemberList.Values.ToList();
        }


    }
}
