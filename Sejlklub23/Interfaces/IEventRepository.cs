using Microsoft.Extensions.Logging;
using Sejlklub23.Models;

namespace Sejlklub23.Interfaces
{
    public interface IEventRepository
    {
        List<Event> GetAllEvents();
        Event GetEvent(int id);
        void CreateEvent(Event ev);
        void DeleteEvent(Event ev);
        void UpdateEvent(Event ev);

    }
}
