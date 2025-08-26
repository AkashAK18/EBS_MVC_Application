using EventBookingSystem.Models;
using System.Collections.Generic;

namespace EventBookingSystem.Repositories
{
    public interface IUserRepository
    {
        User? GetByEmail(string email);
        User? GetByUserName(string userName);
        void Add(User user);
        void Save();
    }
}
