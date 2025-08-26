using EventBookingSystem.Models;
using System.Collections.Generic;

namespace EventBookingSystem.Services
{
    public interface IEventService
    {
        IEnumerable<Event> GetEvents();
        Event GetEvent(int id);
        bool CreateEvent(Event evt, out string error);
        bool UpdateEvent(Event evt, out string error);
        bool DeleteEvent(int id, out string error);
    }
}
