using BoatClubLibrary.BlogData;
using BoatClubLibrary.BoatData;
using BoatClubLibrary.MemberData.MemberService;
using BoatClubLibrary.MockData;

MemberService memberService = new MemberService();

memberService.GetMembers();

Blog blog = new Blog();



Console.WriteLine(blog.CreatePost("test"));

Console.WriteLine(blog.ReadPost(1));

