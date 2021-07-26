// <copyright file="CleaningsController.cs" company="HotelCollab">
// Copyright (c) HotelCollab. All rights reserved.
// </copyright>

namespace HostIsle.Web.Hotels.Areas.Receptionist.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HostIsle.Web.Hotels.Services.Interfaces;
    using HostIsle.Web.Hotels.ViewModels.Hotels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Area("Receptionist")]
    public class CleaningsController : Controller
    {
        private readonly IHotelService hotelService;
        private readonly ICleaningService cleaningService;

        public CleaningsController(IHotelService hotelService, ICleaningService cleaningService)
        {
            this.hotelService = hotelService;
            this.cleaningService = cleaningService;
        }

        [HttpGet]
        public async Task<IActionResult> All(string id, string returnedId) =>
            this.View("~/Views/Cleanings/All.cshtml", await this.hotelService.LoadCurrentHotelAsync(id == null ? returnedId : id));

        [HttpGet]
        public async Task<IActionResult> Add(string id, string returnedId) =>
            this.View("~/Views/Cleanings/Add.cshtml", await this.hotelService.LoadCurrentHotelAsync(id == null ? returnedId : id));

        [HttpPost]
        public async Task<IActionResult> Create(HotelInformationViewModel model, string id)
        {
            await this.cleaningService.CreateAsync(model.CreateCleaningViewModel, id);

            return this.RedirectToAction("All", "Cleanings", new { returnedId = id });
        }

        [HttpPost]
        public async Task<IActionResult> Assign(string id)
        {
            var hotelId = await this.cleaningService.AssignAsync(id);

            return this.RedirectToAction("All", "Cleanings", new { returnedId = hotelId });
        }
    }
}
