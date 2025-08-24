using EventBookingSystem.Models;
using EventBookingSystem.Models.ViewModels;

namespace EventBookingSystem.Services
{
    public interface IAccountService
    {
        bool Register(RegisterViewModel model, out string error);
        User? Login(LoginViewModel model, out string error);
    }
}
