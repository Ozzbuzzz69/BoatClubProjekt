using BoatClubLibrary.MemberData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClubLibrary.EventData
{
    public class Event
    {
        public int Id { get; set; }

        public DateTime PostDate { get; set; }

        public string EventDate { get; set; }

        public string EventDescription { get; set; }

        public List<Member> JoinedMembers { get; set; } = new List<Member>();

        private static int NextId = 1;

        public Event(string eventDate, string eventDescription)
        {
            Id = NextId++;
            PostDate = DateTime.Now;
            EventDate = eventDate;
            EventDescription = eventDescription;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Post date: {PostDate}, Event date: {EventDate}, Event description: {EventDescription}";
        }
    }
}
