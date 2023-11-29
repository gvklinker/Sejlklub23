using Sejlklub23.Models;

namespace Sejlklub23.Interfaces
{
    public interface IBoatRepository
    {
        List<Boat> GetAllBoats();
        Event GetBoat(int id);
        void CreateBoat(Boat boat);
        void DeleteBoat(int id);
        void UpdateBoat(Boat boat);﻿
    }
}
