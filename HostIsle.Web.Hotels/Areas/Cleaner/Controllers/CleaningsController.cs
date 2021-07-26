// <copyright file="CleaningsController.cs" company="HotelCollab">
// Copyright (c) HotelCollab. All rights reserved.
// </copyright>

namespace HostIsle.Web.Hotels.Areas.Cleaner.Controllers
{
    using System.Threading.Tasks;
    using HostIsle.Web.Hotels.Services.Interfaces;
    using HostIsle.Web.Hotels.ViewModels.Hotels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller for the cleanings.
    /// </summary>
    [Authorize]
    [Area("Cleaner")]
    public class CleaningsController : Controller
    {
        private readonly IHotelService hotelService;
        private readonly ICleaningService cleaningService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CleaningsController"/> class.
        /// </summary>
        /// <param name="hotelService"> Access to database, table Hotels. </param>
        /// <param name="cleaningService"> Access to database, table Cleanings. </param>
        public CleaningsController(IHotelService hotelService, ICleaningService cleaningService)
        {
            this.hotelService = hotelService;
            this.cleaningService = cleaningService;
        }

        /// <summary>
        /// Get the upcoming events view.
        /// </summary>
        /// <param name="id"> Id from the base. </param>
        /// <param name="returnedId"> Id from any of the services. </param>
        /// <returns> Returns a view. </returns>
        [HttpGet]
        public async Task<IActionResult> Upcoming(string id, string returnedId)
            => this.View(await this.hotelService.LoadCurrentHotelAsync(id ?? returnedId));

        /// <summary>
        /// Get the past events view.
        /// </summary>
        /// <param name="id"> Id from the base. </param>
        /// <returns> Returns a view. </returns>
        [HttpGet]
        public async Task<IActionResult> Old(string id) => this.View(await this.hotelService.LoadCurrentHotelAsync(id));

        /// <summary>
        /// Method that changes the status from upcoming to cleaned.
        /// </summary>
        /// <param name="model"> Needed information about the cleaning. </param>
        /// <param name="id"> Id from the base. </param>
        /// <returns> Returns the list with upcoming cleanings. </returns>
        [HttpPost]
        public async Task<IActionResult> Clean(HotelInformationViewModel model, string id)
        {
            var hotelId = await this.cleaningService.CleanAsync(model.CleanRoomViewModel, id);

            return this.RedirectToAction("Upcoming", "Cleanings", new { returnedId = hotelId });
        }
    }
}
