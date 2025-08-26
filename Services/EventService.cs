using EventBookingSystem.Models;
using EventBookingSystem.Repositories;
using System.Collections.Generic;

namespace EventBookingSystem.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _repository;

        public EventService(IEventRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Event> GetEvents() => _repository.GetAll();

        public Event GetEvent(int id) => _repository.GetById(id);

        public bool CreateEvent(Event evt, out string error)
        {
            error = "";
            if (evt.AvailableSeats == 0) evt.AvailableSeats = evt.TotalSeats;
            if (evt.AvailableSeats > evt.TotalSeats)
            {
                error = "Available seats cannot exceed total seats.";
                return false;
            }

            _repository.Add(evt);
            _repository.Save();
            return true;
        }

        public bool UpdateEvent(Event evt, out string error)
        {
            error = "";
            if (evt.AvailableSeats > evt.TotalSeats)
            {
                error = "Available seats cannot exceed total seats.";
                return false;
            }

            _repository.Update(evt);
            _repository.Save();
            return true;
        }

        public bool DeleteEvent(int id, out string error)
        {
            error = "";
            var evt = _repository.GetById(id);
            if (evt == null)
            {
                error = "Event not found.";
                return false;
            }
            _repository.Delete(evt);
            _repository.Save();
            return true;
        }
    }
}
