namespace HostIsle.Web.Hotels.Areas.Mananger.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HostIsle.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Area("Manager")]
    public class SignalsController : Controller
    {
        private readonly IHotelService hotelService;
        private readonly ISignalService signalService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignalsController"/> class.
        /// </summary>
        /// <param name="hotelService"></param>
        /// <param name="signalService"></param>
        public SignalsController(IHotelService hotelService, ISignalService signalService)
        {
            this.hotelService = hotelService;
            this.signalService = signalService;
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

            return this.View("~/Views/Signals/All.cshtml");
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> Proccess(string id)
        {
            var hotelId = await this.signalService.ProccessAsync(id);

            return this.RedirectToAction("All", "Signals", new { returnedId = hotelId });
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var hotelId = await this.signalService.DeleteAsync(id);

            return this.RedirectToAction("All", "Signals", new { returnedId = hotelId });
        }
    }
}
