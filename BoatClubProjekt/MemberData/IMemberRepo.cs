using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClubLibrary.MemberData
{
    public interface IMemberRepo
    {
        void CreateMember(Member member);

        bool DeleteMember(int memberId);

        Member UpdateMember(int memberId, Member member);

        void PrintAllMembers();

        Member? ReadMember(int memberId);

        void UpdateTilRazor(Member member);
    }
}
