using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BoatClubLibrary.MemberData.MemberService
{
    public class MemberService : IMembeService
    {
        public List<Member> _members;
        public MemberService()
        {
            _members = MockData.MockMembers.GetMockMembers();
        }
        public List<Member> GetMembers()
        {
            return _members;
        }
        public void AddMember(Member member)
        {
            _members.Add(member);
        }

        public void UpdateMember(Member member)
        {
            if (member != null)
            {
                foreach (Member m in _members)
                {
                    if (m.Id == member.Id)
                    {
                        m.Address = member.Address;
                        m.Email = member.Email;
                        m.MembershipType = member.MembershipType;
                    }
                }
            }
        }

        public Member DeleteMember(int id)
        {
            Member memberToBeDeleted = null!;
            
            foreach (Member m in _members)
            {
                if (id == m.Id)
                {
                    memberToBeDeleted = m;
                    break;
                }
            }
            if (memberToBeDeleted != null)
            {
                _members.Remove(memberToBeDeleted);
            }
            return memberToBeDeleted;
        }

        public Member GetMember(int id)
        {
            foreach (Member m in _members)
            {
                if (m.Id == id)
                    return m;
            }
            return null!;
        }
    }
}
