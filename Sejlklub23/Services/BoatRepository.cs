using Sejlklub23.Interfaces;
using Sejlklub23.Models;
using Sejlklub23.Helpers;

namespace Sejlklub23.Services
{
    public class BoatRepository : IBoatRepository
    {
        //Filename for the Json file we are saving the data in
        private string jsonFileName = @"Data\Boats.json";
        
        //Recieves a boat object and adds it to the current List<> of boats 
        public void CreateBoat(Boat boat)
        {
            List<int> ids = new List<int>();
            List<Boat> boats = GetAllBoats();
            //Looks for through the IDs of the boats
            foreach (var item in boats)
            {
                ids.Add(item.Id);
            }
            //based on whether this is the first entry or not it either gives the boat an ID of 1 or 1+the highest value ID in the current list
            if (ids.Count != 0) 
                boat.Id = ids.Max() + 1;
            else
                boat.Id = 1;
            boats.Add(boat);
            JsonFileWriter<Boat>.WriteToJson(boats, jsonFileName);

        }

        //Removes a boat from the list based on the given ID
        public void DeleteBoat(int id)
        {
            List<Boat> boats = GetAllBoats();
            boats.Remove(boats.Find(boat=>boat.Id == id));
            JsonFileWriter<Boat>.WriteToJson(boats, jsonFileName);
        }

        //Reading all entries in the json file
        public List<Boat> GetAllBoats()
        {
            return  JsonFileReader<Boat>.ReadJson(jsonFileName);
        }

        //Looks through the current list and return a single boat based on the ID
        public Boat GetBoat(int id)
        {
            return GetAllBoats().Find(boat => boat.Id == id);
        }

        //Updates a boat in the list
        public void UpdateBoat(Boat boat)
        {
            //if the object sent is null dont update
            if(boat != null)
            {
                //looks through all the boats in the list and updates the one with a coresponding ID
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
