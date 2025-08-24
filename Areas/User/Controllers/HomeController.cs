using EventBookingSystem.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly EventsBookingDbContext _context;
        public HomeController(EventsBookingDbContext context) => _context = context;

        [HttpGet("/Home/Index")]
        public IActionResult Index(string? q)
        {

            var query = _context.Events.AsQueryable();

            if (!string.IsNullOrWhiteSpace(q))
            {
                query = query.Where(e => e.Title.Contains(q) || e.Location.Contains(q));
                ViewBag.Search = q; // state via ViewBag
            }

            var events = query.Where(e => e.EventDate >= DateTime.Now)
                              .OrderBy(e => e.EventDate)
                              .ToList();

            return View(events); 
        }
    }
}
