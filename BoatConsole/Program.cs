using BoatClubLibrary.BlogData;
using BoatClubLibrary.BoatData;
using BoatClubLibrary.MockData;

//MemberService memberService = new MemberService();

//memberService.GetMembers();

Blog blog = new Blog();

DateTime dt = new DateTime();

Console.WriteLine(blog.CreatePost("test", dt));

Console.WriteLine(blog.ReadPost(1));

Console.WriteLine(blog.CreatePost("test2", dt));

Console.WriteLine(blog.ReadPost(2));

Console.WriteLine();
blog.ReadAllPosts();
