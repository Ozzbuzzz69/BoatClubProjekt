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
        void AddMember(Member member);
        void UpdateMember(Member member);
        Member DeleteMember(int id);
        Member GetMember(int id);
    }
}
