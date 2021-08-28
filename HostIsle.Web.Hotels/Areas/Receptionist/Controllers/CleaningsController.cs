// <copyright file="CleaningsController.cs" company="HotelCollab">
// Copyright (c) HotelCollab. All rights reserved.
// </copyright>

namespace HostIsle.Web.Hotels.Areas.Receptionist.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HostIsle.Services.Interfaces;
using HostIsle.Web.ViewModels.Cleanings;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Area("Receptionist")]
    public class CleaningsController : Controller
    {
        private readonly IHotelService hotelService;
        private readonly ICleaningService cleaningService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CleaningsController"/> class.
        /// </summary>
        /// <param name="hotelService"></param>
        /// <param name="cleaningService"></param>
        public CleaningsController(IHotelService hotelService, ICleaningService cleaningService)
        {
            this.hotelService = hotelService;
            this.cleaningService = cleaningService;
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

            return this.View("~/Views/Cleanings/All.cshtml");
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="returnedId"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet]
        public async Task<IActionResult> Add(string id, string returnedId)
        {
            var model = await this.hotelService.LoadCurrentHotelAsync(id ?? returnedId);

            this.ViewBag.Model = model;

            return this.View("~/Views/Cleanings/Add.cshtml");
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateCleaningViewModel model, string id)
        {
            await this.cleaningService.CreateAsync(model, id);

            return this.RedirectToAction("All", "Cleanings", new { returnedId = id });
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> Assign(string id)
        {
            var hotelId = await this.cleaningService.AssignAsync(id);

            return this.RedirectToAction("All", "Cleanings", new { returnedId = hotelId });
        }
    }
}
