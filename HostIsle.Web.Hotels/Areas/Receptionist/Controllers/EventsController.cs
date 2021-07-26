namespace HostIsle.Web.Hotels.Areas.Receptionist.Controllers
{
    using System.Threading.Tasks;
    using HostIsle.Web.Hotels.Services.Interfaces;
    using HostIsle.Web.Hotels.ViewModels.Hotels;
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
        public async Task<IActionResult> Add(string id) =>
            this.View("~/Views/Events/Add.cshtml", await this.hotelService.LoadCurrentHotelAsync(id));

        [HttpGet]
        public async Task<IActionResult> All(string id, string returnedId) =>
            this.View("~/Views/Events/All.cshtml", await this.hotelService.LoadCurrentHotelAsync(id ?? returnedId));

        [HttpPost]
        public async Task<IActionResult> Create(HotelInformationViewModel model, string id)
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
