using BoatClubLibrary.MemberData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClubLibrary.MockData
{
    public class MockMembers
    {
        private static List<Member> members = new List<Member>()
        {
            new Member("Junior", "12/29/2016", "Silas", "Langtvæk 33", "testost@mail.com"),
            new Member("Normal", "12/29/1995", "Jens", "Langtvæk 44", "testost1@mail.com"),
            new Member("Senior", "12/29/1969", "Ole", "Langtvæk 55", "testost2@mail.com")
        };
        public static List<Member> GetMockMembers()
        {
            return members;
        }
    }
}
