﻿using BoatClubLibrary.BlogData;
using BoatClubLibrary.MemberData;

MemberRepo member = new MemberRepo();

member.Add(new Member("dsfs", "fdsf", "", "", " ", "", false));

member.PrintAllMembers();

Console.WriteLine("diller");
Blog blog = new Blog();

DateTime dt = DateTime.Now;

blog.CreatePost("test", dt);

Console.WriteLine(blog.ReadPost(1));