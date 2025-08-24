using EventBookingSystem.Models;
using EventBookingSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingSystem.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles ="User")]
    [Route("User/[controller]/[action]")]
    public class BookingController : Controller
    {
        private readonly IBookingService _service;

        public BookingController(IBookingService service)
        {
            _service = service;
        }

        private string? CurrentUserId() => HttpContext.Session.GetString("UserId");

        [HttpGet]

        public IActionResult MyBookings()
        {
            var uid = CurrentUserId();
            if (uid is null) return RedirectToAction("Login", "Account", new { area = "" });

            var list = _service.GetUserBookings(uid);
            return View(list); // strongly typed IEnumerable<Booking>
        }

        [HttpPost("{eventId}")]
        [ValidateAntiForgeryToken]
        public IActionResult Book(int eventId)
        {
            var uid = CurrentUserId();
            if (uid is null) return RedirectToAction("Login", "Account", new { area = "" });

            if (_service.BookEvent(eventId, uid, out var error))
            {
                TempData["Message"] = "Booking confirmed!";
                return RedirectToAction("MyBookings");
            }

            TempData["Message"] = error;
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
