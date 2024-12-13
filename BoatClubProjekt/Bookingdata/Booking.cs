using BoatClubLibrary.BoatData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClubLibrary.Bookingdata
{
    public class Booking
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public int BoatId { get; set; }

        private static int NextId = 1;


        public Booking(int memberId, int boatId)
        {
            Id = NextId++;
            MemberId = memberId;
            BoatId = boatId;
        }

        /// <summary>
        /// Validate if the boat with the given ID exists in the repository
        /// </summary>
        /// <param name="boatId"></param>
        /// <returns>
        /// 
        /// </returns>
        public bool ValidateBoat(int boatId)
        {
            return BoatRepo.ReadBoat(boatId) != null;
        }
        //Validate the boat of given ID is rentable
        public bool BoatRentable(int boatId)
        {
            if (BoatRepo.ReadBoat(boatId) != null)
            {
                if (BoatRepo.ReadBoat(boatId)!.IsRented == false) return true;
            }
            return false;
        }
        public void RentBoat(int boatId)
        {
            BoatRepo.RentBoat(boatId);
        }
        public void UnrentBoat(int boatId)
        {
            BoatRepo.UnrentBoat(boatId);
        }


        public override string ToString()
        {
            return $"Id: {Id}, MemberId: {MemberId}, BoatId {BoatId}";
        }
    }
}
