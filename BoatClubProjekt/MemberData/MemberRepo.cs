using BoatClubLibrary.BoatData;
using BoatClubLibrary.Bookingdata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClubLibrary.MemberData
{
    public class MemberRepo : IMemberRepo
    {
        public Dictionary<int, Member> MemberList = new();
        //public List<Boat> _bookableBoats;

        //public MemberRepo()
        //{
        //    _bookableBoats = BoatRepo.GetBoats().ToList();  
        //}

        public void CreateMember(Member member)
        {
            MemberList.TryAdd(member.Id, member);
        }
        public Member? ReadMember(int memberId)
        {
            if (MemberList.TryGetValue(memberId, out Member? value))
            {
                return value;
            }
            return null;
        }
                
        public void UpdateTilRazor(Member member)
        {
            if (ReadMember(member.Id) != null)
            {
                MemberList[member.Id] = member;
            }
        }
        public Member UpdateMember(int memberId, Member member)
        {
            if (ReadMember(memberId) != null)
            {
                MemberList[memberId] = member;
            }
            return member;
        }
        public bool DeleteMember(int memberId)
        {
            if (ReadMember(memberId) != null)
            {
                MemberList.Remove(memberId);
                return true;
            }
            return false;
        }
        public void DeteleForRazor(Member member)
        {
            if (ReadMember(member.Id) != null)
            {
                MemberList.Remove(member.Id);
            }
        }

        public void PrintAllMembers()
        {
            foreach (KeyValuePair<int, Member> member in MemberList)
            {
                Console.WriteLine(member);
            }
        }


    }
}
