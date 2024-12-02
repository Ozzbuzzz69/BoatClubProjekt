using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClubLibrary.BlogData
{
    public class Blog
    {
        public Dictionary<int, Post> Posts {  get; set; } = new Dictionary<int, Post>();

        public bool CreatePost(Post post)
        {
            if (post != null)
            {
                Posts.TryAdd(post.Id, post);
                return true;
            }
            return false;
        }

        public Post? ReadPost(int id)
        {
            if (Posts.ContainsKey(id))
            {
                return Posts[id];
            }
            return null;
        }

        public bool UpdatePost(int id, string eventDescription)
        {
            if (Posts.ContainsKey(id))
            {
                Posts[id].EventDescription = eventDescription;
                return true;
            }
            return false;
        }

        public bool DeletePost(int id)
        {
            if (Posts.ContainsKey(id))
            {
                Posts.Remove(id);
                return true;
            }
            return false;
        }
    }
}
