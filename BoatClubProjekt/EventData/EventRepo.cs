using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatClubLibrary.MemberData;

namespace BoatClubLibrary.EventData
{
    public class EventRepo :IEventRepo
    {

        public Dictionary<int, Event> Events { get; set; } = new Dictionary<int, Event>();
        
           

            

        /// <summary>
        /// Adds event to Events if  e is not equal null, or an Event already contains Event with same Id.
        /// </summary>
        /// <param name="e"></param>
        /// <returns>
        /// Returns true if Event is added to Events, and returns false if e is null or not added.
        /// </returns>
        public  bool CreateEvent(Event e)
        {
            if (e != null)
            {
                Events.TryAdd(e.Id, e);
                return true;
            }
            return false;
        }


        /// <summary>
        /// Reads Event with given id, if Events contains key equal to argument.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Returns Event if Events contains a key equal to id, otherwise it returns null.
        /// </returns>
        public  Event? ReadEvent(int id)
        {
            if (Events.ContainsKey(id))
            {
                return Events[id];
            }
            return null;
        }
        public List<Event> ReadEvents()
        {
            return Events.Values.ToList();
        }


        /// <summary>
        /// Updates Event with matching key as id argument, and updates EventDate and EventDescription,
        /// to eventDate and eventDescription given in argument.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="eventDate"></param>
        /// <param name="eventDescription"></param>
        /// <returns>
        /// Returns true if Event is updated, otherwise it returns false.
        /// </returns>
        public  bool UpdateEvent(int id, string eventDate, string eventDescription)
        {
            if (Events.ContainsKey(id))
            {
                Events[id].EventDate = eventDate;
                Events[id].EventDescription = eventDescription;
                return true;
            }
            return false;
        }


        /// <summary>
        /// Deletes Event with key that matches id argument.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Returns true if Event is deleted, otherwise it returns false.
        /// </returns>
        public  bool DeleteEvent(int id)
        {
            if (Events.ContainsKey(id))
            {
                Events.Remove(id);
                return true;
            }
            return false;
        }

        /// <summary>
        /// A member joins a event via the parameter eventId and the parameter member. It also checks if
        /// the eventId exists in the dictionary Events.
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="member"></param>
        /// <returns>
        /// returns true if the member is joining the event. If the member cant join the event it returns false.
        /// </returns>
        public bool JoinEvent(int eventId, Member member)
        {
            if (Events.ContainsKey(eventId))
            {
                Events[eventId].JoinedMembers.Add(member);
                return true;
            }
            return false;
        }

        public bool LeaveEvent(int eventId, Member member)
        {
            if (!Events.ContainsKey(eventId)) return false;
            Events[eventId].JoinedMembers.Remove(member); return true;
        }

        public override string ToString()
        {
            string message = "Current events: ";
            foreach (KeyValuePair<int, Event> e in Events) { message += e.Value.ToString() + ", "; }
            if (message.Length < 20) { return "No events available"; }
            return message;
        }
    }
}
