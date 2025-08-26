using EventBookingSystem.Models;
using System.Collections.Generic;

namespace EventBookingSystem.Repositories
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();
        Event GetById(int id);
        void Add(Event evt);
        void Update(Event evt);
        void Delete(Event evt);
        void Save();
    }
}
