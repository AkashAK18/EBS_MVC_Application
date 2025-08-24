using EventBookingSystem.Data;
using EventBookingSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace EventBookingSystem.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EventsBookingDbContext _context;

        public EventRepository(EventsBookingDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Event> GetAll() => _context.Events.OrderByDescending(e => e.EventId).ToList();

        public Event GetById(int id) => _context.Events.Find(id);

        public void Add(Event evt) => _context.Events.Add(evt);

        public void Update(Event evt) => _context.Events.Update(evt);

        public void Delete(Event evt) => _context.Events.Remove(evt);

        public void Save() => _context.SaveChanges();
    }
}
