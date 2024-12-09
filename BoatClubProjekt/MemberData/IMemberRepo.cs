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

        Member? ReadMember(int memberId);

        Member UpdateMember(int memberId, Member member);

        void UpdateForRazor(Member member);

        bool DeleteMember(int memberId);

        void DeteleForRazor(Member member);

        void PrintAllMembers();
    }
}
