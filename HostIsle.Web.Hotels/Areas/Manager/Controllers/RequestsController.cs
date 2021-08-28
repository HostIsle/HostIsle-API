namespace HostIsle.Web.Hotels.Areas.Mananger.Controllers
{
    using System.Threading.Tasks;
    using HostIsle.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Area("Manager")]
    public class RequestsController : Controller
    {
        private readonly Manager.Services.Interfaces.IRequestService requestService;
        private readonly IHotelService hotelService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestsController"/> class.
        /// </summary>
        /// <param name="requestService"></param>
        /// <param name="hotelService"></param>
        public RequestsController(Manager.Services.Interfaces.IRequestService requestService, IHotelService hotelService)
        {
            this.requestService = requestService;
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

            return this.View();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> Accept(string id) =>
            this.RedirectToAction(
                "All",
                "Requests",
                new { returnedId = await this.requestService.AcceptAsync(id) });

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> Delete(string id) =>
            this.RedirectToAction(
                "All",
                "Requests",
                new { returnedId = await this.requestService.DeleteAsync(id) });
    }
}
