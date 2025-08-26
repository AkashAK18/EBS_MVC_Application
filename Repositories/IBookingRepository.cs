using EventBookingSystem.Models;
using System.Collections.Generic;

namespace EventBookingSystem.Repositories
{
    public interface IBookingRepository
    {
        IEnumerable<Booking> GetBookingsByUser(string userId);
        Booking? GetBooking(int id);
        void Add(Booking booking);
        void Save();
    }
}
