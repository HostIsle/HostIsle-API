namespace HostIsle.Web.Hotels.Areas.Receptionist.Controllers
{
    using System.Threading.Tasks;
    using HostIsle.Services.Interfaces;
using HostIsle.Web.ViewModels.Events;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Area("Receptionist")]
    public class EventsController : Controller
    {
        private readonly IEventService eventService;
        private readonly IHotelService hotelService;

        public EventsController(IEventService eventService, IHotelService hotelService)
        {
            this.eventService = eventService;
            this.hotelService = hotelService;
        }

        [HttpGet]
        public async Task<IActionResult> Add(string id)
        {
            var model = await this.hotelService.LoadCurrentHotelAsync(id);

            this.ViewBag.Model = model;

            return this.View("~/Views/Events/Add.cshtml");
        }

        [HttpGet]
        public async Task<IActionResult> All(string id, string returnedId)
        {
            var model = await this.hotelService.LoadCurrentHotelAsync(id ?? returnedId);

            this.ViewBag.Model = model;

            return this.View("~/Views/Events/All.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEventViewModel model, string id)
        {
            await this.eventService.CreateAsync(model, id);

            return this.RedirectToAction("All", "Events", new { returnedId = id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await this.eventService.DeleteAsync(id);

            return this.RedirectToAction("All", "Events", new { returnedId = result });
        }
    }
}
