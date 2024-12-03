using BoatClubLibrary.BlogData;
using BoatClubLibrary.BoatData;
<<<<<<< HEAD
using BoatClubLibrary.MemberData;
using BoatClubLibrary;


MemberLibrary memberLibrary = new MemberLibrary();

Blog blog = new Blog();

memberLibrary.Add(new Member());

memberLibrary.PrintAllMembers();

//Console.WriteLine(blog.CreatePost("test"));

Console.WriteLine(blog.ReadPost(1));

//Console.WriteLine(blog.CreatePost("test2"));
=======
using BoatClubLibrary.MockData;

//MemberService memberService = new MemberService();

//memberService.GetMembers();

Blog blog = new Blog();

DateTime dt = new DateTime();

Console.WriteLine(blog.CreatePost("test", dt));

Console.WriteLine(blog.ReadPost(1));½

Console.WriteLine(blog.CreatePost("test2", dt));
>>>>>>> 17786dada4093a06a67d2a75d1e7398105de2a16

Console.WriteLine(blog.ReadPost(2));

Console.WriteLine();
//blog.ReadAllPosts();
