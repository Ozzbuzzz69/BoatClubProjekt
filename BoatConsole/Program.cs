using BoatClubLibrary.BlogData;
using BoatClubLibrary.BoatData;
using BoatClubLibrary.MemberData;
using BoatClubLibrary;


MemberLibrary memberLibrary = new MemberLibrary();

Blog blog = new Blog();

memberLibrary.Add(new Member());

memberLibrary.PrintAllMembers();

//Console.WriteLine(blog.CreatePost("test"));

Console.WriteLine(blog.ReadPost(1));

//Console.WriteLine(blog.CreatePost("test2"));

Console.WriteLine(blog.ReadPost(2));

Console.WriteLine();
//blog.ReadAllPosts();
