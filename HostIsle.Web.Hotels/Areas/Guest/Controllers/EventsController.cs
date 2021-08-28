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

        /// <summary>
        /// Initializes a new instance of the <see cref="EventsController"/> class.
        /// </summary>
        /// <param name="hotelService"></param>
        public EventsController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
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

            return this.View("~/Views/Events/All.cshtml");
        }
    }
}
