﻿using BoatClubLibrary.MemberData;
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

        /// <summary>
        /// Creates a new post, and checks if post is added to dictionary Posts through Id.
        /// </summary>
        /// <param name="post"></param>
        /// <returns>
        /// If so it returns true, otherwise it will return false.
        /// </returns>
        public bool CreatePost(Post post)
        {
            if (post != null)
            {
                Posts.TryAdd(post.Id, post);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if dictionary Posts contains the given id key.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// If so it returns the value connected with the key.
        /// Otherwise it returns null.
        /// </returns>
        public Post? ReadPost(int id)
        {
            if (Posts.ContainsKey(id))
            {
                return Posts[id];
            }
            return null;
        }

        /// <summary>
        /// Checks if dictionary Posts contains the given key id, if so the current value from that key is getting updated,
        /// by setting the current value = the new value.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="post"></param>
        /// <returns>
        /// Returns true if Post is updated, if Post is not updated it returns false.
        /// </returns>
        public bool UpdatePost(int id, string description)
        {
            if (Posts.ContainsKey(id))
            {
                Posts[id].Description = description;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if dictionary Posts contains the given key id, if so it removes the id from dictionary.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Returns true if Post is removed from dictionary, if not it returns false.
        /// </returns>
        public bool DeletePost(int id)
        {
            if (Posts.ContainsKey(id))
            {
                Posts.Remove(id);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Reads all the posts in Posts.
        /// </summary>
        /// <returns>
        /// Returns the posts values in a list of posts.
        /// </returns>
        public List<Post> ReadAllPosts()
        {
            return Posts.Values.ToList();
        }
    }
}