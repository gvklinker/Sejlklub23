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
            List<int> ids = new List<int>();
            List<Boat> boats = GetAllBoats();
            foreach (var item in boats)
            {
                ids.Add(item.Id);
            }
            if (ids.Count != 0) 
                boat.Id = ids.Max() + 1;
            else
                boat.Id = 1;
            boats.Add(boat);
            JsonFileWriter<Boat>.WriteToJson(boats, jsonFileName);

        }

        public void DeleteBoat(int id)
        {
            List<Boat> boats = GetAllBoats();
            boats.Remove(boats.Find(boat=>boat.Id == id));
            JsonFileWriter<Boat>.WriteToJson(boats, jsonFileName);
        }

        public List<Boat> GetAllBoats()
        {
            return  JsonFileReader<Boat>.ReadJson(jsonFileName);
        }

        public Boat GetBoat(int id)
        {
            return GetAllBoats().Find(boat => boat.Id == id);
        }

        public void UpdateBoat(Boat boat)
        {
            if(boat != null)
            {
                List<Boat> boats = GetAllBoats();
                foreach(var item in boats)
                {
                    if(item.Id == boat.Id)
                    {
                        item.Model = boat.Model;
                        item.Name = boat.Name;
                        break;
                    }

                }
                JsonFileWriter<Boat>.WriteToJson(boats, jsonFileName);

            }
        }
    }
}
