using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClubLibrary.EventData
{
    public class EventRepo
    {
        public Dictionary<int, Event> Events { get; set; } = new Dictionary<int, Event>();

        public bool CreateEvent(Event e)
        {
            if (e != null)
            {
                Events.TryAdd(e.Id, e);
                return true;
            }
            return false;
        }

        public Event? ReadEvent(int id)
        {
            if (Events.ContainsKey(id))
            {
                return Events[id];
            }
            return null;
        }

        public bool UpdateEvent(int id, string eventDate, string eventDescription)
        {
            if (Events.ContainsKey(id))
            {
                Events[id].EventDate = eventDate;
                Events[id].EventDescription = eventDescription;
                return true;
            }
            return false;
        }

        public bool DeleteEvent(int id)
        {
            if (Events.ContainsKey(id))
            {
                Events.Remove(id);
                return true;
            }
            return false;
        }

        public string JoinEvent(int id, int memberId)
        {
            return "K"; //Tilføj kode
        }
    }
}
