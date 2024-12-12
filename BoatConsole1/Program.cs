using BoatClubLibrary.BlogData;
using BoatClubLibrary.BoatData;
using BoatClubLibrary.MemberData;


Blog blog = new Blog();

DateTime dt = DateTime.Now;


MemberRepo.CreateMember(new Member("Test", "Test", "Test", "Test", MembershipType.Familie, "Test", true));
MemberRepo.CreateMember(new Member("Test", "hdfi", "Test", "Test", MembershipType.Familie, "Test", true));
MemberRepo.CreateMember(new Member("Test", "ufufu", "Test", "Test", MembershipType.Familie, "Test", true));
MemberRepo.CreateMember(new Member("Test", "1242324", "Test", "Test", MembershipType.Familie, "Test", true));

Console.WriteLine(MemberRepo.ReadMember(1));





Console.WriteLine("\n\n\n\n\n");

Console.WriteLine("-----------------Test af Blog-----------------");


Console.WriteLine("\n\n\n\n\n");




Console.WriteLine("-----------------Test af BoatRepo-----------------");


Console.WriteLine("////////Creating boats:");
Console.WriteLine(BoatRepo.CreateBoat(new Boat(300, "Type", "Model", "Navn", 3, 500, 40, 50.8,  40.5, 20.7, false, "Log")));
Console.WriteLine(BoatRepo.CreateBoat(new Boat(3000, "Type2", "Model2", "Navn2", 30, 5000, 400, 500.8, 400.5, 200.7, false, "Log2")));
Console.WriteLine(BoatRepo.CreateBoat(new Boat(3000, "Type3", "Model3", "Navn3", 30, 5000, 400, 500.8, 400.5, 200.7, false, "Log3")));
Console.WriteLine("\n\n");

Console.WriteLine("//////////Read boat:");
Console.WriteLine(BoatRepo.ReadBoat(1));
Console.WriteLine("\n\n");

Console.WriteLine("////////Update boat:");
//Console.WriteLine(boatRepo.UpdateBoat(2, ));
Console.WriteLine("\n\n");

Console.WriteLine("//////Read boat:");
Console.WriteLine(BoatRepo.ReadBoat(2));
Console.WriteLine("\n\n");

Console.WriteLine("//////Delete boat:");
Console.WriteLine(BoatRepo.DeleteBoat(1));
Console.WriteLine("\n\n");

Console.WriteLine("///////Read all boats:");
BoatRepo.ReadAllBoats();
Console.WriteLine("\n\n");

Console.WriteLine("///////Search boat:");
//Console.WriteLine(BoatRepo.SearchBoat(2500));
Console.WriteLine("\n\n");

Console.WriteLine("//////Get Boats");
foreach (Boat b in BoatRepo.GetBoats())
{
    Console.WriteLine(b);
}
Console.WriteLine("\n\n\n\n\n");
Console.WriteLine("-----------------Test af Booking-----------------");



MemberRepo.UpdateMember(2, new("Test", "osanc", "Test", "Test", MembershipType.Junior, "Test", true));


foreach (Boat b in BoatRepo.GetBoats())
{
    Console.WriteLine(b);
}

Console.WriteLine("\n\n\n\n\n");
Console.WriteLine("-----------------Test af MemberRepo-----------------");
Console.WriteLine("/////Get Members");
foreach (Member m in MemberRepo.GetMembers())
{
    Console.WriteLine(m);
}