using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClubLibrary.MemberData
{
    public class MemberLibrary : IMemberLibrary
    {
        public Dictionary<int, Member> MemberList = new Dictionary<int, Member>();

        public MemberLibrary() { }

        public void Add(Member member)
        {
            MemberList.TryAdd(member.Id, member);
        }

        public bool Remove(Member member)
        {
            if (MemberList.ContainsValue(member))
            {
                MemberList.Remove(member.Id);
            }
            return false;
        }
        
        public Member Update(int memberId, Member member)
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

        public Member GetMember(int memberId)
        {
            return MemberList[memberId];
        }
    }
}
