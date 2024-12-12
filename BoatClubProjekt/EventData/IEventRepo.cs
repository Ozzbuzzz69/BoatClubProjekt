using BoatClubLibrary.MemberData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClubLibrary.EventData
{
    internal interface IEventRepo
    {
        public Event? ReadEvent(int id);
        public bool CreateEvent(Event e);
        public bool UpdateEvent(int id, string eventDate, string eventDescription);
        public bool DeleteEvent(int id);
        public bool JoinEvent(int eventId, Member member);
    }
}
