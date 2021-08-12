namespace HostIsle.Web.Hotels.Areas.Mananger.Controllers
{
    using System.Threading.Tasks;
    using HostIsle.Services.Interfaces;
    using HostIsle.Web.ViewModels.Reservations;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Area("Manager")]
    public class ReservationsController : Controller
    {
        private readonly IHotelService hotelService;
        private readonly IReservationService reservationService;

        public ReservationsController(IHotelService hotelService, IReservationService reservationService)
        {
            this.hotelService = hotelService;
            this.reservationService = reservationService;
        }

        [HttpGet]
        public async Task<IActionResult> All(string id, string returnedId)
        {
            var model = await this.hotelService.LoadCurrentHotelAsync(id ?? returnedId);

            this.ViewBag.Model = model;

            return this.View("~/Views/Reservations/All.cshtml");
        }

        [HttpGet]
        public async Task<IActionResult> Add(string id)
        {
            var model = await this.hotelService.LoadCurrentHotelAsync(id);

            this.ViewBag.Model = model;

            return this.View("~/Views/Reservations/Add.cshtml");
        }

        [HttpGet]
        public async Task<IActionResult> Overview(string id)
        {
            var model = await this.hotelService.LoadCurrentHotelAsync(id);

            this.ViewBag.Model = model;

            return this.View("~/Views/Reservations/Overview.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddReservationViewModel model, string id)
        {
            await this.reservationService.CreateAsync(model, id);

            return this.RedirectToAction("All", "Reservations", new { returnedId = id });
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditReservationViewModel model, string id)
        {
            var hotelId = await this.reservationService.UpdateAsync(model, id);

            return this.RedirectToAction("All", "Reservations", new { returnedId = hotelId });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var hotelId = await this.reservationService.DeleteAsync(id);

            return this.RedirectToAction("All", "Reservations", new { returnedId = hotelId });
        }

        [HttpPost]
        public async Task<IActionResult> Free(string id)
        {
            var hotelId = await this.reservationService.FreeAsync(id);

            return this.RedirectToAction("All", "Reservations", new { returnedId = hotelId });
        }
    }
}
