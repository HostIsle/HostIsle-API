namespace HostIsle.Web.Hotels.Areas.Mananger.Controllers
{
    using System.Threading.Tasks;
    using HostIsle.Web.Hotels.Areas.Manager.Services.Interfaces;
    using HostIsle.Web.Hotels.Services.Interfaces;
    using HostIsle.Web.Hotels.ViewModels.Hotels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Area("Manager")]
    public class RoomsController : Controller
    {
        private readonly IHotelService hotelService;
        private readonly IRoomService roomService;

        public RoomsController(IHotelService hotelService, IRoomService roomService)
        {
            this.hotelService = hotelService;
            this.roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> Add(string id) =>
            this.View(await this.hotelService.LoadCurrentHotelAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(HotelInformationViewModel model, string id)
        {
            await this.roomService.CreateAsync(model, id);

            return this.RedirectToAction("Dashboard", "Home", new { returnedId = id });
        }
    }
}
