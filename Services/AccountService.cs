using EventBookingSystem.Models;
using EventBookingSystem.Models.ViewModels;
using EventBookingSystem.Repositories;
using Microsoft.AspNetCore.Identity;

namespace EventBookingSystem.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _repository;
        private readonly PasswordHasher<User> _passwordHasher;

        public AccountService(IUserRepository repository)
        {
            _repository = repository;
            _passwordHasher = new PasswordHasher<User>();
        }

        public bool Register(RegisterViewModel model, out string error)
        {
            error = "";

            if (_repository.GetByEmail(model.Email) != null)
            {
                error = "Email already in use.";
                return false;
            }
            if (_repository.GetByUserName(model.UserName) != null)
            {
                error = "Username already in use.";
                return false;
            }

            var user = new User
            {
                UserId = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                Email = model.Email,
                Role = "User"
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, model.Password);

            _repository.Add(user);
            _repository.Save();
            return true;
        }

        public User? Login(LoginViewModel model, out string error)
        {
            error = "";
            var user = _repository.GetByEmail(model.Email);

            if (user == null)
            {
                error = "Invalid credentials.";
                return null;
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                error = "Invalid credentials.";
                return null;
            }

            return user;
        }
    }
}
