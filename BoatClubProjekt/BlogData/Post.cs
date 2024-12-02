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

        private static int NextId = 1;

        public Post(string eventDescription)
        {
            Id = NextId++;
            EventDescription = eventDescription;
        }
    }
}
