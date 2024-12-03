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

        public DateTime PostDate { get; set; }

        public DateTime EventDate { get; set; }

        public List<Member> JoinedMembers { get; set; } = new List<Member>();

        private static int NextId = 1;

        public Post(string eventDescription, DateTime postDate, DateTime eventDate)
        {
            Id = NextId++;
            EventDescription = eventDescription;
            PostDate = postDate;
            EventDate = eventDate;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Event description: {EventDescription}, " +
                $"Date of post: {PostDate}, Date of event: {EventDate}";
        }
    }
}
