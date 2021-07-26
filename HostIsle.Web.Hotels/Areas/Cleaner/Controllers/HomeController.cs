// <copyright file="HomeController.cs" company="HotelCollab">
// Copyright (c) HotelCollab. All rights reserved.
// </copyright>

namespace HostIsle.Web.Hotels.Areas.Cleaner.Controllers
{
    using System.Threading.Tasks;
    using HostIsle.Web.Hotels.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller for the index view.
    /// </summary>
    [Authorize]
    [Area("Cleaner")]
    public class HomeController : Controller
    {
        private readonly IHotelService hotelService;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="hotelService"> Access to the database table Hotels. </param>
        public HomeController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }

        /// <summary>
        /// Load view Dashboard of the cleaner.
        /// </summary>
        /// <param name="id"> Id of the current hotel. </param>
        /// <returns> Returns the Dashboard view. </returns>
        [HttpGet]
        public async Task<IActionResult> Dashboard(string id) => this.View(await this.hotelService.LoadCurrentHotelAsync(id));
    }
}
