using BoatClubLibrary.BoatData;
using BoatClubLibrary.Bookingdata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BoatClubLibrary.MemberData
{
    public static class MemberRepo
    {
        private static Dictionary<int, Member> MemberList = new Dictionary<int, Member>();


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

        /// <summary>
        /// Reads all members in MembersList
        /// </summary>
        /// <returns>
        /// Returns the members values in a list of members. If the Memberlist is null then it returns null
        /// </returns>
        public static List<Member>? ReadMemberList()
        {
            if (MemberList != null)
            {
                return MemberList.Values.ToList();
            }
            return null;
        }

        /// <summary>
        /// Checks if the ReadMember method returned a value from the given id key, if so update the value in the given key
        /// to a new value.
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="member"></param>
        /// <returns>
        /// returns the updated member
        /// </returns>
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

    }
}
