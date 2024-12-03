using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClubLibrary.MemberData
{
    public interface IMemberLibrary
    {
        public void Add(Member member);

        public bool Remove(Member member);

        public Member Update(int memberId, Member member);

        public void PrintAllMembers();

        public Member GetMember(int memberId);
    }
}
