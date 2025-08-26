using EventBookingSystem.Data;
using EventBookingSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EventBookingSystem.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly EventsBookingDbContext _context;

        public BookingRepository(EventsBookingDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Booking> GetBookingsByUser(string userId) =>
            _context.Bookings
                .Include(b => b.Event)
                .Where(b => b.UserId == userId)
                .OrderByDescending(b => b.BookingDate)
                .ToList();

        public Booking? GetBooking(int id) => _context.Bookings.Find(id);

        public void Add(Booking booking) => _context.Bookings.Add(booking);

        public void Save() => _context.SaveChanges();
    }
}
