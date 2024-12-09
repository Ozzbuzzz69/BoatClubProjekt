using BoatClubLibrary.MemberData;
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

        public bool CreatePost(string eventDescription, string eventDate)
        {
            Post post = new Post(eventDescription, eventDate);
            bool isAdded = Posts.TryAdd(post.Id, post);
            if (isAdded == true)
            {
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

        public bool UpdatePost(int id, Post post)
        {
            if (Posts.ContainsKey(id))
            {
                Posts[id] = post;
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

        public Member? GetJoinedMembers()
        {
            return null;
        }

        public void ReadAllPosts()
        {
            foreach (Post p in Posts.Values)
            {
                Console.WriteLine(p);
            }
        }
    }
}