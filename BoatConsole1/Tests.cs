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
            bool status = test;
            SuccessTest(status);
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
            // Check for null
            if (MemberRepo.ReadMemberList() == null) { return false; }

            // Read the initial number of members
            int membernumber = MemberRepo.ReadMemberList()!.Count;

            // Generate a full member using tuple from Randotron
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

            // Compare with initial number of members
            return membernumber + 1 == MemberRepo.ReadMemberList()!.Count;
        }

        public static bool Test1B()
        {
            return false;
            //There is no function for it to test, so it can only fail.
        }
        public static bool Test2A()
        {
            // Check for null
            if (MemberRepo.ReadMemberList() == null) { return false; }

            // Read the initial number of members
            int membernumber = MemberRepo.ReadMemberList()!.Count;

            // Generate a full member using tuple from Randotron
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

            // Create an admin
            Admin admin = new(
                Randotron.Generate("person"),
                Randotron.Generate("address"),
                Randotron.Generate("email"),
                Randotron.Generate("phone number")
            ); 
            // Use admin to delete the member
            admin.DeleteMember(member.Id);

            // Compare with initial number of members
            return membernumber == MemberRepo.ReadMemberList()!.Count;
        }
        public static bool Test2B()
        {
            return false;
            // There is no function for it to test, so it can only fail.
        }
        public static bool Test3A()
        {
            // Read the initial number of boats
            int boatnumber = BoatRepo.ReadAllBoats().Count();

            // Create an admin
            Admin admin = new(
                Randotron.Generate("person"),
                Randotron.Generate("address"),
                Randotron.Generate("email"),
                Randotron.Generate("phone number")
            );

            // Generate a full boat using the tuple from Randotron
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
                isRented: boatTuple.IsOperational,
                log: boatTuple.Log);

            // Admin creates the boat (assuming CreateBoat is a method)
            admin.CreateBoat(boat);

            // Verify the number of boats has increased
            int newBoatNumber = BoatRepo.ReadAllBoats().Count();

            // Return true if the boat was added successfully
            return newBoatNumber == boatnumber + 1;
        }
        public static bool Test3B()
        {
            return false;
            // There is no function for it to test, so it can only fail.
        }
        public static bool Test4A()
        {
            //As member has no function for it, we test if the repo can do it. The member would automatically fail.

            // Generate a full boat using the tuple from Randotron
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
                isRented: boatTuple.IsOperational,
                log: boatTuple.Log);
            // Add it to the repo
            BoatRepo.CreateBoat(boat);

            // Returns true if the SearchBoat method can find a boat with the "tester" type
            return BoatRepo.SearchBoat("tester").Count() > 0;
        }
        public static bool Test4B()
        {
            return false;
            // There is no function for it to test, so it can only fail.
        }
        public static bool Test5A()
        {
            // As admin has no function for it, we test if the repo can do it. Admin would automatically fail.

            // We create an event repo
            EventRepo eventRepo = new();

            // We make an event to put in the repo
            Event e = new(Randotron.Generate("birthday"), Randotron.Generate("description"));
            
            // We check if the event can be added to repo
            if (eventRepo.CreateEvent(e))
            {
                //We check if the event can be updated
                if (eventRepo.UpdateEvent(e.Id, Randotron.Generate("birthday"), Randotron.Generate("description")))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool Test5B()
        {
            return false;
            // There is no function for it to test, so it can only fail.
        }
        #endregion
        #region Tests 6-10
        public static bool Test6A()
        {
            // Check for null
            if (MemberRepo.ReadMemberList() == null) { return false; }

            // Generate a full member using tuple from Randotron
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

            // Create an admin
            Admin admin = new(
                Randotron.Generate("person"),
                Randotron.Generate("address"),
                Randotron.Generate("email"),
                Randotron.Generate("phone number")
            );

            // Read the number of members
            int membernumber = MemberRepo.ReadMemberList()!.Count;

            // Check for null
            if (admin.ReadMemberList() == null) { return false; }

            // Use admin's Read function and see if it gives the same number of memebers as MemberRepo's read function
            return admin.ReadMemberList()!.Count == membernumber;
        }
        public static bool Test6B()
        {
            return false;
            // There is no function for it to test, so it can only fail.
        }
        public static bool Test7A() //skal laves rigtigt
        {
            // Since member has no function for it, we instead test the MemberRepo

            // Generate a full member using tuple from Randotron
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

            // Update to give it a new name
            MemberRepo.UpdateMember(member.Id, 
                name: "Tester",
                address: memberTuple.Address,
                email: memberTuple.Email,
                phoneNumber: memberTuple.PhoneNumber,
                membershipType: memberTuple.MembershipType,
                birthday: memberTuple.Birthday,
                isRenting: memberTuple.IsRenting);

            // Check if the member has the new name
            return member.Name == "Tester";
        }
        public static bool Test7B()
        {
            return false;
            // There is no function for it to test, so it can only fail.
        }
        public static bool Test8A()
        {
            // Generate a full member using tuple from Randotron
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

            // Generate a full boat using the tuple from Randotron
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
                isRented: boatTuple.IsOperational,
                log: boatTuple.Log);
            // Add it to the repo
            BoatRepo.CreateBoat(boat);

            // Check if member's BookBoat method gives a valid output
            return member.BookBoat(boat.Id);
        }
        public static bool Test8B()
        {
            // Generate two full members using tuple from Randotron
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
            MemberRepo.CreateMember(member1);
            MemberRepo.CreateMember(member2);

            // Generate a full boat using the tuple from Randotron
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
                isRented: boatTuple.IsOperational,
                log: boatTuple.Log);
            // Add it to the repo
            BoatRepo.CreateBoat(boat);

            // One member books a boat
            member1.BookBoat(boat.Id);

            // Then check if the second member can book the same boat
            return member2.BookBoat(boat.Id);
        }
        public static bool Test9A()
        {
            // Generate two full members using tuple from Randotron
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
            MemberRepo.CreateMember(member1);
            MemberRepo.CreateMember(member2);

            // Generate a full boat using the tuple from Randotron
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
                isRented: boatTuple.IsOperational,
                log: boatTuple.Log);
            // Add it to the repo
            BoatRepo.CreateBoat(boat);

            // One member books a boat
            member1.BookBoat(boat.Id);

            // Check if the other member can see them out sailing
            return member2.ViewCurrentSailors().Count > 0;
        }
        public static bool Test9B() //don't know what is meant with this one's text
        {
            return false;
        }
        public static bool Test10A()
        {
            // Create an admin
            Admin admin = new(
                Randotron.Generate("person"),
                Randotron.Generate("address"),
                Randotron.Generate("email"),
                Randotron.Generate("phone number")
            );

            // Check if the admin's create boat function can be used to create a boat
            // Read the initial number of boats
            int boatnumber = BoatRepo.ReadAllBoats().Count();

            // Generate a full boat using the tuple from Randotron
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
                isRented: boatTuple.IsOperational,
                log: boatTuple.Log);

            // Use admins to create a boat
            return admin.CreateBoat(boat);
        }
        public static bool Test10B()
        {
            return false;
            // There is no function for it to test, so it can only fail.
        }
        public static bool Test10C()
        {
            return false;
            // There is no function for it to test, so it can only fail.
        }



        #endregion
    }
}
