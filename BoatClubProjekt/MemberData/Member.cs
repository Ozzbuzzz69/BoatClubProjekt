﻿using BoatClubLibrary.BoatData;
using BoatClubLibrary.Bookingdata;
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
        public bool BookBoat(int boatId) 
        { 
            Booking Booking = new Booking(Id, boatId);
            if (Booking.ValidateBoat(boatId) && Booking.BoatRentable(boatId)) 
            {
                Booking.RentBoat(boatId);
                return true;
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

