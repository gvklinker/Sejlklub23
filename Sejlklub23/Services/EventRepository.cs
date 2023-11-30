using Sejlklub23.Helpers;
using Sejlklub23.Interfaces;
using Sejlklub23.Models;

namespace Sejlklub23.Services
{
    public class EventRepository : IEventRepository
    {
        private List<Event> _events;
        string jsonFileName = @"Data\Events.json";
        public void CreateEvent(Event ev)
        {
            if (ev != null)
            {
                _events.Add(ev);
            }
        }

        public void DeleteEvent(Event ev)
        {
            for (int i = 0; i < _events.Count; i++)
            {
                if (ev != null || ev.Id == _events[i].Id)
                {
                    _events.RemoveAt(i);
                }
            }
        }

        public List<Event> GetAllEvents()
        {
            return _events;
        }

        public Event GetEvent(int id)
        {
            foreach (Event ev in _events)
            {
                if (ev.Id.Equals(id))
                    return ev;
            }
            return null;
        }

        public void UpdateEvent(Event ev)
        {
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
                    }
                }
            }
        }
    }
}
