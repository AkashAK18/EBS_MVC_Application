using EventBookingSystem.Models;
using System.Collections.Generic;

namespace EventBookingSystem.Services
{
    public interface IBookingService
    {
        IEnumerable<Booking> GetUserBookings(string userId);
        bool BookEvent(int eventId, string userId, out string error);
    }
}
