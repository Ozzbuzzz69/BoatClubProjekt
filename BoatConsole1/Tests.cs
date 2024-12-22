using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatClubLibrary;
using BoatClubLibrary.AdminData;
using BoatClubLibrary.BlogData;
using BoatClubLibrary.Bookingdata;
using BoatClubLibrary.MemberData;
using BoatClubLibrary.BoatData;
using BoatClubLibrary.EventData;

namespace BoatConsole1
{
    public static class Tests
    {
        #region Base functions
        public static void RunTest(string testname,bool test, bool result)
        {
            // Runs the test
            Console.WriteLine($"Running test: {testname}...");

            // Sets a variable so the test result can be used twice and not accidentally changed
            bool status = test;

            // Does runs the test itself, to see if it was successful or not
            SuccessTest(status);

            // Compares the result of the test to the result you were expecting,
            // to tell if we got the result we were looking for
            PrintTest(status, result);
        }
        public static bool SuccessTest(bool test)
        {
            // Does the actual test and returns the result
            if (test == true) { Console.WriteLine("Test was successful"); return true; }
            else { Console.WriteLine("Test has failed"); }
            return false;
        }
        public static void PrintTest(bool test, bool result)
        {
            // Checks the result compared to what we expect to see
            if (test == result) Console.WriteLine("Result as expected.");
            else Console.WriteLine("Result NOT as expected");
        }
        #endregion
        #region Tests 1-5
        public static bool Test1A()
        {
            Console.WriteLine("Running test 1A\n");

            // Check for null
            if (MemberRepo.ReadMemberList() == null) { return false; }

            // Read the initial number of members
            int membernumber = MemberRepo.ReadMemberList()!.Count;
            Console.WriteLine($"Repo has {membernumber} members");

			// Generate a full member using tuple from Randotron
			Console.WriteLine("Generating a member");
			var memberTuple = Randotron.FullMember();
            Member member = new Member(
                name: memberTuple.Name,
                address: memberTuple.Address,
                email: memberTuple.Email,
                phoneNumber: memberTuple.PhoneNumber,
                membershipType: memberTuple.MembershipType,
                birthday: memberTuple.Birthday,
                isRenting: memberTuple.IsRenting);

            // Add the member to the repo
            MemberRepo.CreateMember(member);
			Console.WriteLine("Adding member to repo");

			// Compare with initial number of members
			Console.WriteLine($"New number of members is {MemberRepo.ReadMemberList()!.Count}");
			return membernumber + 1 == MemberRepo.ReadMemberList()!.Count;
        }
        public static bool Test1B()
        {
			Console.WriteLine("Running test 1B\n");
			Console.WriteLine("Test failed automatically");
            return false;
            //There is no function for it to test, so it can only fail.
        }
        public static bool Test2A()
        {
			Console.WriteLine("Running test 2A\n");
			// Check for null
			if (MemberRepo.ReadMemberList() == null) { return false; }

            // Read the initial number of members
            int membernumber = MemberRepo.ReadMemberList()!.Count;
			Console.WriteLine($"Repo has {membernumber} members");

			// Generate a full member using tuple from Randotron
			Console.WriteLine("Generating a member");
			var memberTuple = Randotron.FullMember();
            Member member = new Member(
                name: memberTuple.Name,
                address: memberTuple.Address,
                email: memberTuple.Email,
                phoneNumber: memberTuple.PhoneNumber,
                membershipType: memberTuple.MembershipType,
                birthday: memberTuple.Birthday,
                isRenting: memberTuple.IsRenting);
            // Add the member to the repo
            Console.WriteLine("Adding member to repo");
            MemberRepo.CreateMember(member);

			// Create an admin
			Console.WriteLine("Generating an admin");
			Admin admin = new(
                Randotron.Generate("person"),
                Randotron.Generate("address"),
                Randotron.Generate("email"),
                Randotron.Generate("phone number")
            );
            // Use admin to delete the member
            Console.WriteLine("Use admin to delete the member");
            admin.DeleteMember(member.Id);

            // Compare with initial number of members
            Console.WriteLine($"New number of members is {MemberRepo.ReadMemberList()!.Count}");
            return membernumber == MemberRepo.ReadMemberList()!.Count;
        }
        public static bool Test2B()
        {
			Console.WriteLine("Running test 2B\n");
			Console.WriteLine("Test failed automatically");
			return false;
            // There is no function for it to test, so it can only fail.
        }
        public static bool Test3A()
        {
			Console.WriteLine("Running test 3A\n");
			// Read the initial number of boats
			int boatnumber = BoatRepo.ReadAllBoats().Count();
			Console.WriteLine($"Repo has {boatnumber} boats");

			// Create an admin
			Console.WriteLine("Generating an admin");
			Admin admin = new(
                Randotron.Generate("person"),
                Randotron.Generate("address"),
                Randotron.Generate("email"),
                Randotron.Generate("phone number")
            );

            // Generate a full boat using the tuple from Randotron
            Console.WriteLine("Generating a boat");
			var boatTuple = Randotron.FullBoat();
            Boat boat = new Boat(
                rentalPrice: boatTuple.Price,
                type: boatTuple.Type,
                model: boatTuple.Model,
                name: boatTuple.Name,
                regNumber: boatTuple.RegNumber,
                horsePower: boatTuple.HorsePower,
                knots: boatTuple.Knots,
                height: boatTuple.Height,
                length: boatTuple.Length,
                width: boatTuple.Width,
                isRented: boatTuple.isRented,
                log: boatTuple.Log);

            // Admin creates the boat (assuming CreateBoat is a method)
            Console.WriteLine("Admin adds boat to repo");
            admin.CreateBoat(boat);

            // Verify the number of boats has increased
            int newBoatNumber = BoatRepo.ReadAllBoats().Count();
            Console.WriteLine($"Repo has {boatnumber} boats");

            // Return true if the boat was added successfully
            Console.WriteLine("Check if boat amount increased...");
            return newBoatNumber == boatnumber + 1;
        }
        public static bool Test3B()
        {
			Console.WriteLine("Running test 3B\n");
			Console.WriteLine("Test failed automatically");
			return false;
            // There is no function for it to test, so it can only fail.
        }
        public static bool Test4A()
        {
			Console.WriteLine("Running test 4A\n");
			//As member has no function for it, we test if the repo can do it. The member would automatically fail.

			// Generate a full boat using the tuple from Randotron
			Console.WriteLine("Generating a boat");
			var boatTuple = Randotron.FullBoat();
            Boat boat = new Boat(
                rentalPrice: boatTuple.Price,
                "tester",
                model: boatTuple.Model,
                name: boatTuple.Name,
                regNumber: boatTuple.RegNumber,
                horsePower: boatTuple.HorsePower,
                knots: boatTuple.Knots,
                height: boatTuple.Height,
                length: boatTuple.Length,
                width: boatTuple.Width,
                isRented: boatTuple.isRented,
                log: boatTuple.Log);
            // Add it to the repo
            Console.WriteLine("Adding boat to repo");
            BoatRepo.CreateBoat(boat);

            // Returns true if the SearchBoat method can find a boat with the "tester" type
            Console.WriteLine("Check if boat has the new name...");
            return BoatRepo.SearchBoat("tester").Count() > 0;
        }
        public static bool Test4B()
        {
			Console.WriteLine("Running test 4B\n");
			Console.WriteLine("Test failed automatically");
			return false;
            // There is no function for it to test, so it can only fail.
        }
        public static bool Test5A()
        {
			Console.WriteLine("Running test 5A\n");
			// As admin has no function for it, we test if the repo can do it. Admin would automatically fail.

			// We create an event repo
            Console.WriteLine("Create an event repo");
			EventRepo eventRepo = new();

            // We make an event to put in the repo
            Console.WriteLine("Generate an event");
            Event e = new(Randotron.Generate("birthday"), Randotron.Generate("description"));

            // We check if the event can be added to repo
            Console.WriteLine("Check if event can be added to repo");
            if (eventRepo.CreateEvent(e))
            {
                Console.WriteLine("Adding event to repo");
                Console.WriteLine("Check if event can be updated in repo");
                //We check if the event can be updated
                if (eventRepo.UpdateEvent(e.Id, Randotron.Generate("birthday"), Randotron.Generate("description")))
                {
                    Console.WriteLine("Updating event...");
                    return true;
                }
            }
            return false;
        }
        public static bool Test5B()
        {
			Console.WriteLine("Running test 5B\n");
			Console.WriteLine("Test failed automatically");
			return false;
            // There is no function for it to test, so it can only fail.
        }
        #endregion
        #region Tests 6-10
        public static bool Test6A()
        {
			Console.WriteLine("Running test 6A\n");
			// Check for null
			if (MemberRepo.ReadMemberList() == null) { return false; }

			// Generate a full member using tuple from Randotron
			Console.WriteLine("Generating a boat");
			var memberTuple = Randotron.FullMember();
            Member member = new Member(
                name: memberTuple.Name,
                address: memberTuple.Address,
                email: memberTuple.Email,
                phoneNumber: memberTuple.PhoneNumber,
                membershipType: memberTuple.MembershipType,
                birthday: memberTuple.Birthday,
                isRenting: memberTuple.IsRenting);
            // Add the member to the repo
            Console.WriteLine("Adding member to repo");
            MemberRepo.CreateMember(member);

			// Create an admin
			Console.WriteLine("Generating an admin");
			Admin admin = new(
                Randotron.Generate("person"),
                Randotron.Generate("address"),
                Randotron.Generate("email"),
                Randotron.Generate("phone number")
            );

            // Read the number of members
            int membernumber = MemberRepo.ReadMemberList()!.Count;
            Console.WriteLine($"Repo has {membernumber} members");

            // Check for null
            if (admin.ReadMemberList() == null) { return false; }

            // Use admin's Read function and see if it gives the same number of memebers as MemberRepo's read function
            Console.WriteLine($"Use admin to get number of members: {admin.ReadMemberList()!.Count}");
            return admin.ReadMemberList()!.Count == membernumber;
        }
        public static bool Test6B()
        {
			Console.WriteLine("Running test 6B\n");
			Console.WriteLine("Test failed automatically");
			return false;
            // There is no function for it to test, so it can only fail.
        }
        public static bool Test7A()
        {
			Console.WriteLine("Running test 7A\n");
			// Since member has no function for it, we instead test the MemberRepo

			// Generate a full member using tuple from Randotron
			Console.WriteLine("Generating a member");
			var memberTuple = Randotron.FullMember();
            Member member = new Member(
                name: memberTuple.Name,
                address: memberTuple.Address,
                email: memberTuple.Email,
                phoneNumber: memberTuple.PhoneNumber,
                membershipType: memberTuple.MembershipType,
                birthday: memberTuple.Birthday,
                isRenting: memberTuple.IsRenting);
            // Add the member to the repo
            Console.WriteLine("Adding member to repo");
            MemberRepo.CreateMember(member);

            // Update to give it a new name
            Console.WriteLine("Updating member name...");
            MemberRepo.UpdateMember(member.Id, 
                name: "Tester",
                address: memberTuple.Address,
                email: memberTuple.Email,
                phoneNumber: memberTuple.PhoneNumber,
                membershipType: memberTuple.MembershipType,
                birthday: memberTuple.Birthday,
                isRenting: memberTuple.IsRenting);

            // Check if the member has the new name
            Console.WriteLine("Check if member has a new name...");
            return member.Name == "Tester";
        }
        public static bool Test7B()
        {
			Console.WriteLine("Running test 7B\n");
			Console.WriteLine("Test failed automatically");
			return false;
            // There is no function for it to test, so it can only fail.
        }
        public static bool Test8A()
        {
			Console.WriteLine("Running test 8A\n");
			// Generate a full member using tuple from Randotron
			Console.WriteLine("Generating a member");
			var memberTuple = Randotron.FullMember();
            Member member = new Member(
                name: memberTuple.Name,
                address: memberTuple.Address,
                email: memberTuple.Email,
                phoneNumber: memberTuple.PhoneNumber,
                membershipType: memberTuple.MembershipType,
                birthday: memberTuple.Birthday,
                isRenting: memberTuple.IsRenting);
            // Add the member to the repo
            Console.WriteLine("Adding member to repo");
            MemberRepo.CreateMember(member);

			// Generate a full boat using the tuple from Randotron
			Console.WriteLine("Generating a boat");
			var boatTuple = Randotron.FullBoat();
            Boat boat = new Boat(
                rentalPrice: boatTuple.Price,
                type: boatTuple.Type,
                model: boatTuple.Model,
                name: boatTuple.Name,
                regNumber: boatTuple.RegNumber,
                horsePower: boatTuple.HorsePower,
                knots: boatTuple.Knots,
                height: boatTuple.Height,
                length: boatTuple.Length,
                width: boatTuple.Width,
                isRented: boatTuple.isRented,
                log: boatTuple.Log);
            // Add it to the repo
            Console.WriteLine("Adding boat to repo");
            BoatRepo.CreateBoat(boat);

            // Check if member's BookBoat method gives a valid output
            Console.WriteLine("Check if member can book a boat...");
            return member.BookBoat(boat.Id);
        }
        public static bool Test8B()
        {
			Console.WriteLine("Running test 8B\n");
			// Generate two full members using tuple from Randotron
			Console.WriteLine("Generating two members");
			var memberTuple1 = Randotron.FullMember();
            Member member1 = new Member(
                name: memberTuple1.Name,
                address: memberTuple1.Address,
                email: memberTuple1.Email,
                phoneNumber: memberTuple1.PhoneNumber,
                membershipType: memberTuple1.MembershipType,
                birthday: memberTuple1.Birthday,
                isRenting: memberTuple1.IsRenting);
            var memberTuple2 = Randotron.FullMember();
            Member member2 = new Member(
                name: memberTuple2.Name,
                address: memberTuple2.Address,
                email: memberTuple2.Email,
                phoneNumber: memberTuple2.PhoneNumber,
                membershipType: memberTuple2.MembershipType,
                birthday: memberTuple2.Birthday,
                isRenting: memberTuple2.IsRenting);
            // Add the members to the repo
            Console.WriteLine("Adding members to repo");
            MemberRepo.CreateMember(member1);
            MemberRepo.CreateMember(member2);

			// Generate a full boat using the tuple from Randotron
			Console.WriteLine("Generating a boat");
			var boatTuple = Randotron.FullBoat();
            Boat boat = new Boat(
                rentalPrice: boatTuple.Price,
                type: boatTuple.Type,
                model: boatTuple.Model,
                name: boatTuple.Name,
                regNumber: boatTuple.RegNumber,
                horsePower: boatTuple.HorsePower,
                knots: boatTuple.Knots,
                height: boatTuple.Height,
                length: boatTuple.Length,
                width: boatTuple.Width,
                isRented: boatTuple.isRented,
                log: boatTuple.Log);
            // Add it to the repo
            Console.WriteLine("Adding boat to repo");
            BoatRepo.CreateBoat(boat);

            // One member books a boat
            Console.WriteLine("One member books boat");
            member1.BookBoat(boat.Id);

            // Then check if the second member can book the same boat
            Console.WriteLine("Check if second member can book boat...");
            return member2.BookBoat(boat.Id);
        }
        public static bool Test9A()
        {
			Console.WriteLine("Running test 9A\n");
			// Generate two full members using tuple from Randotron
			Console.WriteLine("Generating two members");
			var memberTuple1 = Randotron.FullMember();
            Member member1 = new Member(
                name: memberTuple1.Name,
                address: memberTuple1.Address,
                email: memberTuple1.Email,
                phoneNumber: memberTuple1.PhoneNumber,
                membershipType: memberTuple1.MembershipType,
                birthday: memberTuple1.Birthday,
                isRenting: memberTuple1.IsRenting);
            var memberTuple2 = Randotron.FullMember();
            Member member2 = new Member(
                name: memberTuple2.Name,
                address: memberTuple2.Address,
                email: memberTuple2.Email,
                phoneNumber: memberTuple2.PhoneNumber,
                membershipType: memberTuple2.MembershipType,
                birthday: memberTuple2.Birthday,
                isRenting: memberTuple2.IsRenting);
            // Add the members to the repo
            Console.WriteLine("Adding members to repo");
            MemberRepo.CreateMember(member1);
            MemberRepo.CreateMember(member2);

			// Generate a full boat using the tuple from Randotron
			Console.WriteLine("Generating a boat");
			var boatTuple = Randotron.FullBoat();
            Boat boat = new Boat(
                rentalPrice: boatTuple.Price,
                type: boatTuple.Type,
                model: boatTuple.Model,
                name: boatTuple.Name,
                regNumber: boatTuple.RegNumber,
                horsePower: boatTuple.HorsePower,
                knots: boatTuple.Knots,
                height: boatTuple.Height,
                length: boatTuple.Length,
                width: boatTuple.Width,
                isRented: boatTuple.isRented,
                log: boatTuple.Log);
            // Add it to the repo
            Console.WriteLine("Adding boat to repo");
            BoatRepo.CreateBoat(boat);

            // One member books a boat
            Console.WriteLine("One member books boat");
            member1.BookBoat(boat.Id);

            // Check if the other member can see them out sailing
            Console.WriteLine("Other member checks if anyone is current renting");
            return member2.ViewCurrentSailors().Count > 0;
        }
        public static bool Test9B()
        {
			Console.WriteLine("Running test 9B\n");
			Console.WriteLine("Test failed automatically");
			return false;
        }
        public static bool Test10A()
        {
			Console.WriteLine("Running test 10A\n");
			// Create an admin
			Console.WriteLine("Generating an admin");
			Admin admin = new(
                Randotron.Generate("person"),
                Randotron.Generate("address"),
                Randotron.Generate("email"),
                Randotron.Generate("phone number")
            );

            // Check if the admin's create boat function can be used to create a boat
            // Read the initial number of boats
            int boatnumber = BoatRepo.ReadAllBoats().Count();
			Console.WriteLine($"Repo has {boatnumber} boats");

			// Generate a full boat using the tuple from Randotron
			Console.WriteLine("Generating a boat");
			var boatTuple = Randotron.FullBoat();
            Boat boat = new Boat(
                rentalPrice: boatTuple.Price,
                type: boatTuple.Type,
                model: boatTuple.Model,
                name: boatTuple.Name,
                regNumber: boatTuple.RegNumber,
                horsePower: boatTuple.HorsePower,
                knots: boatTuple.Knots,
                height: boatTuple.Height,
                length: boatTuple.Length,
                width: boatTuple.Width,
                isRented: boatTuple.isRented,
                log: boatTuple.Log);

            // Use admins to create a boat
            Console.WriteLine("Check if admin can create a boat");
            return admin.CreateBoat(boat);
        }
        public static bool Test10B()
        {
			Console.WriteLine("Running test 10B\n");
			Console.WriteLine("Test failed automatically");
			return false;
            // There is no function for it to test, so it can only fail.
        }
        public static bool Test10C()
        {
			Console.WriteLine("Running test 10C\n");
			Console.WriteLine("Test failed automatically");
			return false;
            // There is no function for it to test, so it can only fail.
        }
        #endregion
        #region Tests 11-15
        public static bool Test11A()
        {
			Console.WriteLine("Running test 11A\n");
			// Admin has no function for senting to reperation, so instead it will act as if the boat gets rented

			// Create an admin
			Console.WriteLine("Generating an admin");
			Admin admin = new(
                Randotron.Generate("person"),
                Randotron.Generate("address"),
                Randotron.Generate("email"),
                Randotron.Generate("phone number")
            );
			// Generate a full boat using the tuple from Randotron
			Console.WriteLine("Generating a boat");
			var boatTuple = Randotron.FullBoat();
            Boat boat = new Boat(
                rentalPrice: boatTuple.Price,
                type: boatTuple.Type,
                model: boatTuple.Model,
                name: boatTuple.Name,
                regNumber: boatTuple.RegNumber,
                horsePower: boatTuple.HorsePower,
                knots: boatTuple.Knots,
                height: boatTuple.Height,
                length: boatTuple.Length,
                width: boatTuple.Width,
                isRented: boatTuple.isRented,
                log: boatTuple.Log);
            // Add it to the repo
            Console.WriteLine("Adding boat to repo");
            BoatRepo.CreateBoat(boat);

            // Check if boat is rented prior
            Console.WriteLine("Checks the rental status of boat...");
            bool status = boat.IsRented;

            // Admin rents boat
            Console.WriteLine("Admin rents boat...");
            admin.RentBoat(boat.Id);

            // Compare prior rented status to after admin rental
            Console.WriteLine("Check if boat has successfully been rented");
            return status!=boat.IsRented;
        }
        public static bool Test11B()
        {
			Console.WriteLine("Running test 11B\n");
			Console.WriteLine("Test failed automatically");
			// Member can technically use the same method as in Test11A, renting a boat to send it for repairs,
			// but since it has no actual function, it will be set to the default of fail

			return false;
        }
        public static bool Test12A()
        {
			Console.WriteLine("Running test 12A\n");
			// Create an admin
			Console.WriteLine("Generating an admin");
			Admin admin = new(
                Randotron.Generate("person"),
                Randotron.Generate("address"),
                Randotron.Generate("email"),
                Randotron.Generate("phone number")
            );
			// Generate a full boat using the tuple from Randotron
			Console.WriteLine("Generating a boat");
			var boatTuple = Randotron.FullBoat();
            Boat boat = new Boat(
                rentalPrice: boatTuple.Price,
                type: boatTuple.Type,
                model: boatTuple.Model,
                name: boatTuple.Name,
                regNumber: boatTuple.RegNumber,
                horsePower: boatTuple.HorsePower,
                knots: boatTuple.Knots,
                height: boatTuple.Height,
                length: boatTuple.Length,
                width: boatTuple.Width,
                isRented: boatTuple.isRented,
                log: boatTuple.Log);
            // Add it to the repo
            Console.WriteLine("Adding boat to repo");
            BoatRepo.CreateBoat(boat);

            // Check for null
            if (admin.ReadBoat(boat.Id) == null) return false;

            // Check if admin can get the log via ReadBoat, and it has something in it
            Console.WriteLine("Check if admin can see a boat's log");
            if (admin.ReadBoat(boat.Id)!.Log != null && admin.ReadBoat(boat.Id)!.Log.Length > 0 )
            {
                Console.WriteLine("Admin reading log...");
                return true;
            }
            return false;
        }
        public static bool Test12B()
        {
			Console.WriteLine("Running test 12B\n");
			Console.WriteLine("Test failed automatically");
			return false;
            // There is no function for it to test, so it can only fail.
        }
        public static bool Test13A()
        {
			Console.WriteLine("Running test 13A\n");
            // Admin has no function to test, so instead we test if the EventRepo can create events

            // We create an event repo
            Console.WriteLine("Create an event repo");
            EventRepo eventRepo = new();

            // We make an event to put in the repo
            Console.WriteLine("Make an event to");
            Event e = new(Randotron.Generate("birthday"), Randotron.Generate("description"));

            // We check if the event can be added to repo
            Console.WriteLine("Check if event can be added to repo");
            if (eventRepo.CreateEvent(e))
            {
                Console.WriteLine("Adding event to repo");
                Console.WriteLine("Check if event can be updated in repo");
                //We check if the event can be updated
                if (eventRepo.UpdateEvent(e.Id, Randotron.Generate("birthday"), Randotron.Generate("description")))
                {
                    Console.WriteLine("Updating event...");
                    return true;
                }
            }
            return false;
        }
        public static bool Test13B()
        {
			Console.WriteLine("Running test 13B\n");
			Console.WriteLine("Test failed automatically");
			return false;
            // There is no function for it to test, so it can only fail.
        }
        public static bool Test14A()
        {
			Console.WriteLine("Running test 14A\n");
            // Admin has no function to test, so instead we test if the Blog can create posts and delete them
            // We create a blog
            Console.WriteLine("Creating a blog");
			Blog blog = new();

            // Read the initial number of boats
            int postnumber = blog.ReadAllPosts().Count;
			Console.WriteLine($"Repo has {postnumber} posts");

			// Make a post to put on the blog
			Console.WriteLine("Generating a post");
			Post post = new(Randotron.Generate("description"));

            // Add the post to the blog
            Console.WriteLine("Adding post to blog");
            blog.CreatePost(post);

            // Check if the post was added
            Console.WriteLine("Check if post was added");
            if (postnumber + 1 != blog.ReadAllPosts().Count) { return false; }

            // Delete the post 
            Console.WriteLine("Use blog to delete the member");
            blog.DeletePost(post.Id);

            // Check if the post was deleted
            Console.WriteLine("Check if post was deleted");
            if (postnumber != blog.ReadAllPosts().Count) { return false; }
            return true;
        }
        public static bool Test14B()
        {
			Console.WriteLine("Running test 14B\n");
			Console.WriteLine("Test failed automatically");
			return false;
            // There is no function for it to test, so it can only fail.
        }
        public static bool Test15A()
        {
			Console.WriteLine("Running test 15A\n");
			Console.WriteLine("Test failed automatically");
			// We have not implemented such a function, so it get passed as a default

			return true;
        }
        public static bool Test15B()
        {
			Console.WriteLine("Running test 15B\n");
			Console.WriteLine("Test failed automatically");
			// We have not implemented such a function, so it gets failed as a default

			return false;
        }
        public static bool Test16A()
        {
			Console.WriteLine("Running test 16A\n");
			// Admin has no function to test, so instead we test if the Blog can update
			// We create a blog
			Console.WriteLine("Creating a blog");
			Blog blog = new();

            // Read the initial number of boats
            int postnumber = blog.ReadAllPosts().Count;
			Console.WriteLine($"Repo has {postnumber} posts");

            // Make a post to put on the blog
            Console.WriteLine("Generating post for blog");
            Post post = new(Randotron.Generate("description"));

			// Add the post to the blog
			Console.WriteLine("Adding post to blog");
			blog.CreatePost(post);

            // Update post with a new description
            Console.WriteLine("Updating post description using blog");
            blog.UpdatePost(post.Id, "tester");

            // Check for null
            if (blog.ReadPost(post.Id)==null) { return false; }

            // Check if it has the new description
            Console.WriteLine("Checking if post description has been updated");
            return blog.ReadPost(post.Id)!.Description == "tester";
        }
        public static bool Test16B()
        {
			Console.WriteLine("Running test 16B\n");
			Console.WriteLine("Test failed automatically");
			return false;
            // There is no function for it to test, so it can only fail.
        }
        #endregion
    }
}
