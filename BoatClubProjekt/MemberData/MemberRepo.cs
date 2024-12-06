using BoatClubLibrary.BoatData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClubLibrary.MemberData
{
    public class MemberRepo : IMemberRepo
    {
        public Dictionary<int, Member> MemberList = new Dictionary<int, Member>();
        public List<Boat> _bookableBoats;

        //public MemberRepo()
        //{
        //    _bookableBoats = BoatRepo.GetBoats().ToList();  
        //}

        public void CreateMember(Member member)
        {
            MemberList.TryAdd(member.Id, member);
        }

        public bool DeleteMember(int memberId)
        {
            if (MemberList.ContainsKey(memberId))
            {
                MemberList.Remove(memberId);
                return true;
            }
            return false;
        }
        
        public void UpdateTilRazor(Member member)
        {
            if (MemberList.ContainsKey(member.Id))
            {
                MemberList[member.Id] = member;
            }
        }
        public Member UpdateMember(int memberId, Member member)
        {
            if (MemberList.ContainsKey(memberId))
            {
                MemberList[memberId] = member;
            }
            return member;
        }

        public void PrintAllMembers()
        {
            foreach (var m in MemberList)
            {
                Console.WriteLine(m);
            }
        }

        public Member ReadMember(int memberId)
        {
            return MemberList[memberId];
        }
    }
}
