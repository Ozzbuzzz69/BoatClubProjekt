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

        public string Description { get; set; }

        public DateTime PostDate { get; }

        private static int NextId = 1;

        public Post(string description)
        {
            Id = NextId++;
            Description = description;
            PostDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Description: {Description}, " +
                $"Date of post: {PostDate}";
        }
    }
}
