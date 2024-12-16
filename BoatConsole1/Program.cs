using BoatClubLibrary.AdminData;
using BoatClubLibrary.BlogData;
using BoatClubLibrary.BoatData;
using BoatClubLibrary.Bookingdata;
using BoatClubLibrary.EventData;
using BoatClubLibrary.MemberData;
using BoatClubLibrary;
using BoatConsole1;


#region New Tests
Tests.RunTest("1A", Tests.Test1A(), true);
Console.WriteLine();

Tests.RunTest("1B", Tests.Test1B(), false);
Console.WriteLine();

Tests.RunTest("2A", Tests.Test2A(), true);
Console.WriteLine();

Tests.RunTest("2B", Tests.Test2B(), false);
Console.WriteLine(); 

Tests.RunTest("3A", Tests.Test3A(), true);
Console.WriteLine(); 

Tests.RunTest("3B", Tests.Test3B(), false);
Console.WriteLine(); 

Tests.RunTest("4A", Tests.Test4A(), true);
Console.WriteLine(); 

Tests.RunTest("4B", Tests.Test4B(), false);
Console.WriteLine(); 

Tests.RunTest("5A", Tests.Test5A(), true);
Console.WriteLine(); 

Tests.RunTest("5B", Tests.Test5B(), false);
Console.WriteLine();
#endregion

#region Old Tests
Blog blog = new Blog();
EventRepo eventRepo = new EventRepo();

Console.WriteLine("-----------------Test af Blog-----------------");
Console.WriteLine("////////Create Post:");
Post post1 = new Post("Test1");
Post post2 = new Post("Test2");
Post post3 = new Post("Test3");
blog.CreatePost(post1);
blog.CreatePost(post2);
blog.CreatePost(post3);
blog.CreatePost(post3);

Console.WriteLine("\n\n");
Console.WriteLine("////////Read Post:");
Console.WriteLine(blog.ReadPost(1));

Console.WriteLine("\n\n");
Console.WriteLine("////////Update Post:");
blog.UpdatePost(3, new Post("1 million beer"));

Console.WriteLine("\n\n");
Console.WriteLine("////////Delete Post:");
blog.DeletePost(2);

Console.WriteLine("\n\n");
Console.WriteLine("////////Read all Post:");
foreach (Post p in blog.ReadAllPosts())
{
    Console.WriteLine(p);
}

Console.WriteLine("\n\n\n\n\n");
Console.WriteLine("-----------------Test af BoatRepo-----------------");

Console.WriteLine("////////Creating boats:");
Boat boat1 = new Boat(3000, "Type1", "Model1", "Navn1", 1, 3000, 100, 100.1, 400.4, 200.2, false, "Log1");
Boat boat2 = new Boat(4000, "Type2", "Model2", "Navn2", 2, 4000, 200, 200.2, 500.5, 300.3, true, "Log2");
Boat boat3 = new Boat(5000, "Type3", "Model3", "Navn3", 3, 5000, 300, 300.3, 600.6, 400.4, false, "Log3");
Console.WriteLine("\n\n");

Console.WriteLine("//////////Read boat:");
Console.WriteLine(BoatRepo.ReadBoat(1));
Console.WriteLine("\n\n");

Console.WriteLine("////////Update boat:");

Console.WriteLine("\n\n");

Console.WriteLine("//////Read boat:");
Console.WriteLine(BoatRepo.ReadBoat(2));
Console.WriteLine("\n\n");

Console.WriteLine("//////Delete boat:");
Console.WriteLine(BoatRepo.DeleteBoat(1));
Console.WriteLine("\n\n");

Console.WriteLine("///////Read all boats:");

Console.WriteLine("\n\n");

Console.WriteLine("///////Search boat:");

Console.WriteLine("\n\n");

Console.WriteLine("//////Get Boats");
foreach (Boat b in BoatRepo.ReadAllBoats())
{
    Console.WriteLine(b);
}


Console.WriteLine("\n\n\n\n\n");
Console.WriteLine("-----------------Test af Booking-----------------");








Console.WriteLine("\n\n\n\n\n");
Console.WriteLine("-----------------Test af MemberRepo-----------------");

Console.WriteLine("////////Creating Members:");
Member meber1 = new Member("Test1", "Test1", "Test1", "Test1", MembershipType.Senior, "Test1", true);
Member meber2 = new Member("Test2", "Test2", "Test2", "Test2", MembershipType.Junior, "Test2", false);
Member meber3 = new Member("Test3", "Test3", "Test3", "Test3", MembershipType.Familie, "Test3", true);


Console.WriteLine("/////Get Members");
if (MemberRepo.ReadMemberList() != null)
{
    foreach (Member m in MemberRepo.ReadMemberList()!)
    {
        Console.WriteLine(m);
    }
}

Console.WriteLine("\n\n\n\n\n");
Console.WriteLine("----------------Test af EventRepo------------------");

eventRepo.CreateEvent(new("3", "3"));
eventRepo.JoinEvent(0, meber3);

Console.WriteLine(eventRepo.ToString());
#endregion