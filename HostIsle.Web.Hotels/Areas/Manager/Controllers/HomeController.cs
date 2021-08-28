// <copyright file="HomeController.cs" company="HotelCollab">
// Copyright (c) HotelCollab. All rights reserved.
// </copyright>

namespace HostIsle.Web.Hotels.Areas.Mananger.Controllers
{
    using System.Threading.Tasks;
    using HostIsle.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Area("Manager")]
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
        /// <param name="returnedId"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet]
        public async Task<IActionResult> Dashboard(string id, string returnedId)
        {
            var model = await this.hotelService.LoadCurrentHotelAsync(id ?? returnedId);

            this.ViewBag.Model = model;

            return this.View();
        }
    }
}
