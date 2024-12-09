using BoatClubLibrary.MemberData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClubLibrary.BlogData
{
    public class Post
    {
        public int Id { get; set; }

        public string EventDescription { get; set; }

        public DateTime PostDate { get; }

        public string EventDate { get; set; }

        public List<Member> JoinedMembers { get; set; } = new List<Member>();

        private static int NextId = 1;

        public Post(string eventDescription, string eventDate)
        {
            Id = NextId++;
            EventDescription = eventDescription;
            PostDate = DateTime.Now;
            EventDate = eventDate;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Event description: {EventDescription}, " +
                $"Date of post: {PostDate}, Date of event: {EventDate}";
        }
    }
}
