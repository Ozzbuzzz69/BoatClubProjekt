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
        /// <returns>
        /// Returns true if member is added to MemberList, and false if member is not added.
        /// </returns>
        public static bool CreateMember(Member member)
        {
            if (member != null)
            {
                MemberList.TryAdd(member.Id, member);
                return true;
            }
            return false;
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
        /// Returns true if member is updated, and false if member is not.
        /// </returns>
        public static bool UpdateMember(int memberId, string name, string address, string email, string phoneNumber, MembershipType membershipType,
            string birthday, bool isRenting)
        {
            if (ReadMember(memberId) != null)
            {
                MemberList[memberId].Name = name;
                MemberList[memberId].Address = address;
                MemberList[memberId].Email = email;
                MemberList[memberId].PhoneNumber = phoneNumber;
                MemberList[memberId].MembershipType = membershipType;
                MemberList[memberId].Birthday = birthday;
                MemberList[memberId].IsRenting = isRenting;
                return true;
            }
            return false;
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
    }
}
