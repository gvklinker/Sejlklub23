using Sejlklub23.Interfaces;
using Sejlklub23.Models;
using Sejlklub23.Helpers;

namespace Sejlklub23.Services
{
    public class BoatRepository : IBoatRepository
    {
        private string jsonFileName = "@Data/Boats.json";
        
        public void CreateBoat(Boat boat)
        {
            List<int> ints = new List<int>();
            List<Boat> boats = GetAllBoats();

        }

        public void DeleteBoat(int id)
        {
            throw new NotImplementedException();
        }

        public List<Boat> GetAllBoats()
        {
            return  JsonFileReader<Boat>.ReadJson(jsonFileName);
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
