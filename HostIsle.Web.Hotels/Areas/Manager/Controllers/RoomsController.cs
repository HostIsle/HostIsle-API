namespace HostIsle.Web.Hotels.Areas.Mananger.Controllers
{
    using System.Threading.Tasks;
    using HostIsle.Services.Interfaces;
    using HostIsle.Web.Hotels.Areas.Manager.Services.Interfaces;
    using HostIsle.Web.ViewModels.Rooms;
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
        public async Task<IActionResult> Add(string id)
        {
            var model = await this.hotelService.LoadCurrentHotelAsync(id);

            this.ViewBag.Model = model;

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoomRegisterViewModel model, string id)
        {
            await this.roomService.CreateAsync(model, id);

            return this.RedirectToAction("Dashboard", "Home", new { returnedId = id });
        }
    }
}
