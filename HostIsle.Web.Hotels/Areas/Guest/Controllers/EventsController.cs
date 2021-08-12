namespace HostIsle.Web.Hotels.Areas.Guest.Controllers
{
    using System.Threading.Tasks;
    using HostIsle.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Area("Guest")]
    public class EventsController : Controller
    {
        private readonly IHotelService hotelService;

        public EventsController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }

        [HttpGet]
        public async Task<IActionResult> All(string id, string returnedId)
        {
            var model = await this.hotelService.LoadCurrentHotelAsync(id ?? returnedId);

            this.ViewBag.Model = model;

            return this.View("~/Views/Events/All.cshtml");
        }
    }
}
