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
        Event? ReadEvent(int id);
        bool CreateEvent(Event e);
        bool UpdateEvent(int id, string eventDate, string eventDescription);
        bool DeleteEvent(int id);
        bool JoinEvent(int eventId, Member member);
        bool LeaveEvent(int eventId, Member member);
    }
}
