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

BoatRepo boatRepo = new BoatRepo();

Console.WriteLine(boatRepo.CreateBoat(new(1, "t", "t", "t", 3, 3, 3, 3, 3, 3, false, "t")));