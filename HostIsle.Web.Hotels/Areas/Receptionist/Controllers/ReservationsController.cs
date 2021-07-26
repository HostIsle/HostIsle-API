namespace HostIsle.Web.Hotels.Areas.Receptionist.Controllers
{
    using System.Threading.Tasks;
    using HostIsle.Web.Hotels.Services.Interfaces;
    using HostIsle.Web.Hotels.ViewModels.Hotels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Area("Receptionist")]
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
        public async Task<IActionResult> All(string id, string returnedId) =>
            this.View("~/Views/Reservations/All.cshtml", await this.hotelService.LoadCurrentHotelAsync(id == null ? returnedId : id));

        [HttpGet]
        public async Task<IActionResult> Add(string id) =>
            this.View("~/Views/Reservations/Add.cshtml", await this.hotelService.LoadCurrentHotelAsync(id));

        [HttpGet]
        public async Task<IActionResult> Overview(string id) =>
            this.View("~/Views/Reservations/Overview.cshtml", await this.hotelService.LoadCurrentHotelAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(HotelInformationViewModel model, string id)
        {
            await this.reservationService.CreateAsync(model.AddReservationViewModel, id);

            return this.RedirectToAction("All", "Reservations", new { returnedId = id });
        }

        [HttpPost]
        public async Task<IActionResult> Update(HotelInformationViewModel model, string id)
        {
            var hotelId = await this.reservationService.UpdateAsync(model.EditReservationViewModel, id);

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
