using Sejlklub23.Helpers;
using Sejlklub23.Interfaces;
using Sejlklub23.Models;

namespace Sejlklub23.Services
{
    public class EventRepository : IEventRepository
    {
        string jsonFileName = @"Data\Events.json";

        public void CreateEvent(Event ev)
        {
            List<int> ids = new List<int>();
            List<Event> events = GetAllEvents();
            foreach (var item in events)
                 ids.Add(item.Id);
            if (ids.Count != 0)
                ev.Id = ids.Max() + 1;
            else
                ev.Id = 1;
            if (ev != null)
            {
                events.Add(ev);
                JsonFileWriter<Event>.WriteToJson(events, jsonFileName);
            }
        }

        public void DeleteEvent(Event ev) {
            List<Event> events = GetAllEvents();
            events.Remove(events.Find(x=>x.Id == ev.Id));
            JsonFileWriter<Event>.WriteToJson(events, jsonFileName);
        }

        public List<Event> GetAllEvents()
        {
            return JsonFileReader<Event>.ReadJson(jsonFileName); ;
        }

        public Event GetEvent(int id)
        {
            List<Event> events = GetAllEvents();
            foreach (Event ev in events)
            {
                if (ev.Id.Equals(id))
                    return ev;
            }
            return null;
        }

        public void UpdateEvent(Event ev)
        {
            List<Event> _events = GetAllEvents();
            if (ev != null)
            {
                foreach(Event e in _events)
                {
                    if (e.Id.Equals(ev.Id))
                    {
                        e.Title = ev.Title;
                        e.Description = ev.Description;
                        e.EventDuration = ev.EventDuration;
                        e.Address = ev.Address;
                        e.StartOfEvent = ev.StartOfEvent;
                        e.Attendees.AddRange(ev.Attendees);
                        JsonFileWriter<Event>.WriteToJson(_events, jsonFileName);
                        break;
                    }
                }
            }
        }
    }
}
