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
        /// 
        /// </summary>
        /// <param name="member"></param>
        public static void UpdateForRazor(Member member)
        {
            if (ReadMember(member.Id) != null)
            {
                MemberList[member.Id] = member;
            }
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

        public static List<Member> GetMembers()
        {
            return MemberList.Values.ToList();
        }

        /// <summary>
        /// Function to take in the name of an attribute and a value for it and then find the
        /// first object which matches the search.
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static Member? SearchMember(string attribute, object Value)
        {
            if (MemberList.Count > 0)
            {
                foreach (KeyValuePair<int, Member> member in MemberList)
                {
                    //set the property we are looking for
                    var property = member.Value.GetType().GetProperty(attribute.ToString());

                    /* Skal nok slettes
                    //set Value to the type we looked for
                    var ValueType = Convert.ChangeType(Value, property.PropertyType);
                    */

                    //check not null
                    if (property == null) { continue; }

                    //go through each property to check its type and value for comparison with the search
                    foreach (PropertyInfo memberProperty in member.Value.GetType().GetProperties())
                    {
                        if (memberProperty.PropertyType == property.PropertyType)
                        {
                            //return correct value
                            if (memberProperty.GetValue(member) == Value) return member.Value;
                        }
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// Function to give the name of an attribute and a value for it, to then get
        /// every object of matching the criteria
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static List<Member> FilterMember(string attribute, object Value)
        {
            List<Member> list = new();

            if (MemberList.Count > 0)
            {
                foreach (KeyValuePair<int, Member> member in MemberList)
                {
                    //set the property we are looking for
                    var property = member.Value.GetType().GetProperty(attribute.ToString());

                    /* Skal nok slettes
                    //set Value to the type we looked for
                    var ValueType = Convert.ChangeType(Value, property.PropertyType);
                    */

                    //check not null
                    if (property == null) { continue; }

                    //go through each property to check its type and value for comparison with the search
                    foreach (PropertyInfo memberProperty in member.Value.GetType().GetProperties())
                    {
                        if (memberProperty.PropertyType == property.PropertyType)
                        {
                            //add correct value to list
                            if (memberProperty.GetValue(member) == Value) list.Add(member.Value);
                        }
                    }
                }
            }
            //return finished list
            return list;
        }

    }
}
