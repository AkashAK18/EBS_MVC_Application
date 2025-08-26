using EventBookingSystem.Data;
using EventBookingSystem.Models;
using System.Linq;

namespace EventBookingSystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EventsBookingDbContext _context;

        public UserRepository(EventsBookingDbContext context)
        {
            _context = context;
        }

        public User? GetByEmail(string email) =>
            _context.Users.FirstOrDefault(u => u.Email == email);

        public User? GetByUserName(string userName) =>
            _context.Users.FirstOrDefault(u => u.UserName == userName);

        public void Add(User user) => _context.Users.Add(user);

        public void Save() => _context.SaveChanges();
    }
}
