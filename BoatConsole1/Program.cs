using BoatClubLibrary.BlogData;
using BoatClubLibrary.BoatData;
using BoatClubLibrary.MemberData;

MemberRepo member = new MemberRepo();

//member.Add(new Member("dsfs", "fdsf", "", "", , "", false));

member.PrintAllMembers();

Console.WriteLine("diller");
Blog blog = new Blog();

DateTime dt = DateTime.Now;


member.CreateMember(new Member("Test", "Test", "Test", "Test", MembershipType.Familie, "Test", true));

Console.WriteLine(member.ReadMember(1));





Console.WriteLine("\n\n\n\n\n");

Console.WriteLine("-----------------Test af Blog-----------------");


Console.WriteLine("\n\n\n\n\n");

Console.WriteLine("-----------------Test af BoatRepo-----------------");

BoatRepo boatRepo = new BoatRepo();

Console.WriteLine("////////Creating boats:");
Console.WriteLine(boatRepo.CreateBoat(new Boat(300, "Type", "Model", "Navn", 3, 500, 40, 50.8,  40.5, 20.7, false, "Log")));
Console.WriteLine(boatRepo.CreateBoat(new Boat(3000, "Type2", "Model2", "Navn2", 30, 5000, 400, 500.8, 400.5, 200.7, false, "Log2")));
Console.WriteLine(boatRepo.CreateBoat(new Boat(3000, "Type3", "Model3", "Navn3", 30, 5000, 400, 500.8, 400.5, 200.7, false, "Log3")));
Console.WriteLine("\n\n");

Console.WriteLine("//////////Read boat:");
Console.WriteLine(boatRepo.ReadBoat(1));
Console.WriteLine("\n\n");

Console.WriteLine("////////Update boat:");
//Console.WriteLine(boatRepo.UpdateBoat(2, ));
Console.WriteLine("\n\n");

Console.WriteLine("//////Read boat:");
Console.WriteLine(boatRepo.ReadBoat(2));
Console.WriteLine("\n\n");

Console.WriteLine("//////Delete boat:");
Console.WriteLine(boatRepo.DeleteBoat(1));
Console.WriteLine("\n\n");

Console.WriteLine("///////Read all boats:");
boatRepo.ReadAllBoats();
Console.WriteLine("\n\n");

Console.WriteLine("///////Search boat:");
Console.WriteLine(boatRepo.SearchBoat(2500));
Console.WriteLine("\n\n");