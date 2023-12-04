﻿using Sejlklub23.Interfaces;
using Sejlklub23.Models;
using Sejlklub23.Helpers;
namespace Sejlklub23.Services
{
    public class ReservationRepository : IReservationRepository
    {

        private string fileNameJson = @"Data\Reservations.json"; 
        public void CreateReservation(Reservation res)
        {
            List<int> ids = new List<int>();
            List<Reservation> reservs = GetAllReservations();
            //Looks for through the IDs of the reservationss
            foreach (var item in reservs)
            {
                ids.Add(item.Id);
            }
            //based on whether this is the first entry or not it either gives the boat an ID of 1 or 1+the highest value ID in the current list
            if (ids.Count != 0)
               res.Id = ids.Max() + 1;
            else
                res.Id = 1;
            reservs.Add(res);
            JsonFileWriter<Reservation>.WriteToJson(reservs, fileNameJson);
        }

        public void DeleteReservation(int id)
        {
            List<Reservation> reservations = GetAllReservations();
            reservations.Remove(reservations.Find(x=>x.Id==id));
            JsonFileWriter<Reservation>.WriteToJson(reservations, fileNameJson);

        }

        public List<Reservation> GetAllReservations()
        {
            return JsonFileReader<Reservation>.ReadJson(fileNameJson);
        }

        public Reservation GetReservation(int id)
        {
            return GetAllReservations().Find(x => x.Id == id);
        }

        public void UpdateReservation(Reservation res)
        {
            //if the object sent is null dont update
            if (res != null)
            {
                //looks through all the reservations in the list and updates the one with a coresponding ID
                List<Reservation> reservations = GetAllReservations();
                foreach (var item in reservations)
                {
                    if (item.Id == res.Id)
                    {
                        item.IsReturned = res.IsReturned;
                        item.LocationDuration = res.LocationDuration;
                        item.StartOfLocation = res.StartOfLocation;
                        item.BoatId = res.BoatId;
                        item.MemberId = res.MemberId;
                        break;
                    }
                }
                JsonFileWriter<Reservation>.WriteToJson(reservations, fileNameJson);

            }
        }
    }
}
