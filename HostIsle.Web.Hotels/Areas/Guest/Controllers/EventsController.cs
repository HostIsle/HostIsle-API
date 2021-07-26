namespace HostIsle.Web.Hotels.Areas.Guest.Controllers
{
    using System.Threading.Tasks;
    using HostIsle.Web.Hotels.Services.Interfaces;
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
        public async Task<IActionResult> All(string id, string returnedId) =>
            this.View("~/Views/Events/All.cshtml", await this.hotelService.LoadCurrentHotelAsync(id == null ? returnedId : id));
    }
}
