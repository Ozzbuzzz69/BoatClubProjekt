using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClubLibrary.MemberData
{
    public interface IMemberRepo
    {
        public void CreateMember(Member member);

        public bool DeleteMember(int memberId);

        public Member UpdateMember(int memberId, Member member);

        public void PrintAllMembers();

        public Member? ReadMember(int memberId);

        public void UpdateTilRazor(Member member);

    }
}
