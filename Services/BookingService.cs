using EventBookingSystem.Models;
using EventBookingSystem.Repositories;
using System.Collections.Generic;

namespace EventBookingSystem.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepo;
        private readonly IEventRepository _eventRepo;

        public BookingService(IBookingRepository bookingRepo, IEventRepository eventRepo)
        {
            _bookingRepo = bookingRepo;
            _eventRepo = eventRepo;
        }

        public IEnumerable<Booking> GetUserBookings(string userId) =>
            _bookingRepo.GetBookingsByUser(userId);

        public bool BookEvent(int eventId, string userId, out string error)
        {
            error = "";
            var evt = _eventRepo.GetById(eventId);
            if (evt == null)
            {
                error = "Event not found.";
                return false;
            }

            if (evt.AvailableSeats <= 0)
            {
                error = "No seats available.";
                return false;
            }

            evt.AvailableSeats -= 1;
            _eventRepo.Update(evt);

            var booking = new Booking
            {
                EventId = evt.EventId,
                UserId = userId,
                BookingDate = DateTime.UtcNow
            };

            _bookingRepo.Add(booking);

            _eventRepo.Save();   // save event update
            _bookingRepo.Save(); // save booking
            return true;
        }
    }
}
