using EventBookingSystem.Models;
using EventBookingSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace EventBookingSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [Route("Admin/Event")]
    public class EventController : Controller
    {
        private readonly IEventService _service;

        public EventController(IEventService service)
        {
            _service = service;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var list = _service.GetEvents();
            return View(list);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View(new Event { EventDate = DateTime.Now.AddDays(1) });
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Event model)
        {
            if (!ModelState.IsValid) return View(model);

            if (_service.CreateEvent(model, out var error))
            {
                TempData["Message"] = "Event created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", error);
            return View(model);
        }

        [HttpGet("Edit/{id:int}")]
        public IActionResult Edit(int id)
        {
            var evt = _service.GetEvent(id);
            if (evt == null) return NotFound();
            return View(evt);
        }

        [HttpPost("Edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Event model)
        {
            if (id != model.EventId) return BadRequest();
            if (!ModelState.IsValid) return View(model);

            if (_service.UpdateEvent(model, out var error))
            {
                TempData["Message"] = "Event updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", error);
            return View(model);
        }

        [HttpGet("Details/{id:int}")]
        public IActionResult Details(int id)
        {
            var evt = _service.GetEvent(id);
            if (evt == null) return NotFound();
            return View(evt);
        }

        [HttpGet("Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var evt = _service.GetEvent(id);
            if (evt == null) return NotFound();
            return View(evt);
        }

        [HttpGet("DeletePartial/{id:int}")]
        public IActionResult DeletePartial(int id)
        {
            var evt = _service.GetEvent(id);
            if (evt == null) return NotFound();
            return PartialView("_DeletePartial", evt);
        }

        [HttpPost("Delete/{id:int}")]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_service.DeleteEvent(id, out var error))
            {
                TempData["Message"] = "Event deleted.";
                return Ok();
            }

            TempData["Error"] = error;
            return BadRequest();
        }
    }
}
