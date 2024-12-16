using BoatClubLibrary.BoatData;
using BoatClubLibrary.Bookingdata;
using BoatClubLibrary.EventData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BoatClubLibrary.MemberData
{
    public enum MembershipType
    {
        Junior,
        Senior,
        Familie
    }

    public class Member : Person
    {   
        public MembershipType MembershipType { get; set; }
        public string Birthday { get; set; } = string.Empty;

        public bool IsRenting { get; set; }

        private static int NextId = 1;

        public Member() { }
        public Member(string name, string address, string email, string phoneNumber, MembershipType membershipType, 
            string birthday, bool isRenting) : base(name, address, email, phoneNumber)
        {
            Id = NextId++;
            MembershipType = membershipType;
            Birthday = birthday;
            IsRenting = isRenting;
        }

        #region Booking without event

        /// <summary>
        /// Takes the parameter boatid to create a new booking, it also checks if the boat is valid and if
        /// the boat is rentable. It also checks if the member already did rent a boat via the property IsRenting.
        /// </summary>
        /// <param name="boatId"></param>
        /// <returns>
        /// Returns true if the booking goes through, if not it returns false
        /// </returns>
        public bool BookBoat(int boatId) 
        {
            Booking Booking = new Booking(Id, boatId);
            if (BookingRepo.CreateBooking(Booking) == true)
            {
                if (Booking.ValidateBoat(boatId) && Booking.BoatRentable(boatId) && IsRenting == false)
                {
                    Booking.RentBoat(boatId);
                    IsRenting = true;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks which members who has the property Isrenting true in the MemberRepo. If the property is true
        /// the members are added as sailors to the list. 
        /// </summary>
        /// <returns>
        /// Returns the members who is currently renting boats.
        /// </returns>
        public List<Member>? ViewCurrentSailors()
        {
            List<Member> Sailors = new();
            if (MemberRepo.ReadMemberList() != null)
            {
                foreach (var Member in MemberRepo.ReadMemberList()!)
                {
                    if (Member.IsRenting) Sailors.Add(Member);
                }
            }
            return Sailors;
        }

        /// <summary>
        /// checks if a member is renting a boat via Id. 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>
        /// Returns the given member if the member is renting a boat and out sailing. if the members property is 
        /// false then it returns null
        /// </returns>
        public Member? ViewCurrentSailor(int Id)
        {
            if (MemberRepo.ReadMemberList() != null)
            {
                foreach (var Member in MemberRepo.ReadMemberList()!)
                {
                    if (Member.IsRenting && Member.Id==Id) return Member;
                }
            }
            return null;
        }

        public bool JoinEvent(int eventId, EventRepo repo)
        {
            if (MemberRepo.ReadMember(Id) != null)
            {
                if (repo.JoinEvent(eventId, MemberRepo.ReadMember(Id)!))
                {
                    return true;
                }
            }
            return false;
        }
        public bool LeaveEvent(int eventId, EventRepo repo)
        {
            if (MemberRepo.ReadMember(Id) != null)
            {
                if (repo.LeaveEvent(eventId, MemberRepo.ReadMember(Id)!))
                {
                    return true;
                }
            }
            return false;
        }



        #endregion
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Address: {Address}, Birthday: {Birthday}, " +
                $"Email: {Email}, Membership Type: {MembershipType}, Is renting: {IsRenting}";
        }
    }
}

