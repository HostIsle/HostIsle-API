namespace HostIsle.Web.Hotels.Areas.Receptionist.Controllers
{
    using System.Threading.Tasks;
    using HostIsle.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Area("Receptionist")]
    public class HomeController : Controller
    {
        private readonly IHotelService hotelService;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="hotelService"></param>
        public HomeController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet]
        public async Task<IActionResult> Dashboard(string id)
        {
            var model = await this.hotelService.LoadCurrentHotelAsync(id);

            this.ViewBag.Model = model;

            return this.View();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet]
        public async Task<IActionResult> Cleanings(string id)
        {
            var model = await this.hotelService.LoadCurrentHotelAsync(id);

            this.ViewBag.Model = model;

            return this.View();
        }
    }
}
