using Sejlklub23.Interfaces;
using Sejlklub23.Models;

namespace Sejlklub23.Services
{
    public class BoatRepository : IBoatRepository
    {
        private string jsonFileName = "@Data/Boats.json";
        public void CreateBoat(Boat boat)
        {
            throw new NotImplementedException();
        }

        public void DeleteBoat(int id)
        {
            throw new NotImplementedException();
        }

        public List<Boat> GetAllBoats()
        {
            throw new NotImplementedException();
        }

        public Event GetBoat(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateBoat(Boat boat)
        {
            throw new NotImplementedException();
        }
    }
}
