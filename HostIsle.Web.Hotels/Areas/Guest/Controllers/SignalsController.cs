namespace HostIsle.Web.Hotels.Areas.Guest.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using HostIsle.Services.Interfaces;
    using HostIsle.Web.Hotels.Areas.Guest.ViewModels.Signals;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Area("Guest")]
    public class SignalsController : Controller
    {
        private readonly IHotelService hotelService;
        private readonly Services.Interfaces.ISignalService signalService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignalsController"/> class.
        /// </summary>
        /// <param name="hotelService"></param>
        /// <param name="signalService"></param>
        public SignalsController(IHotelService hotelService, Services.Interfaces.ISignalService signalService)
        {
            this.hotelService = hotelService;
            this.signalService = signalService;
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

            return this.View();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateSignalViewModel model, string id)
        {
            var hotelId = await this.signalService.CreateAsync(model, id);

            return this.RedirectToAction(
                "All",
                "Signals",
                new { returnedId = hotelId });
        }
    }
}
