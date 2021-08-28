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

        /// <summary>
        /// Initializes a new instance of the <see cref="ReservationsController"/> class.
        /// </summary>
        /// <param name="hotelService"></param>
        /// <param name="reservationService"></param>
        public ReservationsController(IHotelService hotelService, IReservationService reservationService)
        {
            this.hotelService = hotelService;
            this.reservationService = reservationService;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="returnedId"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet]
        public async Task<IActionResult> All(string id, string returnedId)
        {
            var model = await this.hotelService.LoadCurrentHotelAsync(id ?? returnedId);

            this.ViewBag.Model = model;

            return this.View("~/Views/Reservations/All.cshtml");
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

            return this.View("~/Views/Reservations/Add.cshtml");
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet]
        public async Task<IActionResult> Overview(string id)
        {
            var model = await this.hotelService.LoadCurrentHotelAsync(id);

            this.ViewBag.Model = model;

            return this.View("~/Views/Reservations/Overview.cshtml");
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(AddReservationViewModel model, string id)
        {
            await this.reservationService.CreateAsync(model, id);

            return this.RedirectToAction("All", "Reservations", new { returnedId = id });
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> Update(EditReservationViewModel model, string id)
        {
            var hotelId = await this.reservationService.UpdateAsync(model, id);

            return this.RedirectToAction("All", "Reservations", new { returnedId = hotelId });
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var hotelId = await this.reservationService.DeleteAsync(id);

            return this.RedirectToAction("All", "Reservations", new { returnedId = hotelId });
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> Free(string id)
        {
            var hotelId = await this.reservationService.FreeAsync(id);

            return this.RedirectToAction("All", "Reservations", new { returnedId = hotelId });
        }
    }
}
