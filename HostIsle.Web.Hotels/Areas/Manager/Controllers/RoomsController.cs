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

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomsController"/> class.
        /// </summary>
        /// <param name="hotelService"></param>
        /// <param name="roomService"></param>
        public RoomsController(IHotelService hotelService, IRoomService roomService)
        {
            this.hotelService = hotelService;
            this.roomService = roomService;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet]
        public async Task<IActionResult> Add(string id)
        {
            var model = await this.hotelService.LoadCurrentHotelAsync(id);

            this.ViewBag.Model = model;

            return this.View();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(RoomRegisterViewModel model, string id)
        {
            await this.roomService.CreateAsync(model, id);

            return this.RedirectToAction("Dashboard", "Home", new { returnedId = id });
        }
    }
}
