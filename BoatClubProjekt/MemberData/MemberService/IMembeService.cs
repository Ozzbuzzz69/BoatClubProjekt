using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClubLibrary.MemberData.MemberService
{
    internal interface IMembeService
    {
        List<Member> GetMembers();
        public void AddMember(Member member);
        public void UpdateMember(Member member);
        public Member DeleteMember(int id);
        public Member GetMember(int id);
    }
}
