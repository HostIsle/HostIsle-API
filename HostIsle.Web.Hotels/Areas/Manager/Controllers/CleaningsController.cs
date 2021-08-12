// <copyright file="CleaningsController.cs" company="HotelCollab">
// Copyright (c) HotelCollab. All rights reserved.
// </copyright>

namespace HostIsle.Web.Hotels.Areas.Mananger.Controllers
{
    using System.Threading.Tasks;
    using HostIsle.Services.Interfaces;
using HostIsle.Web.ViewModels.Cleanings;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Area("Manager")]
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
        public async Task<IActionResult> All(string id, string returnedId)
        {
            var model = await this.hotelService.LoadCurrentHotelAsync(id ?? returnedId);

            this.ViewBag.Model = model;

            return this.View("~/Views/Cleanings/All.cshtml");
        }

        [HttpGet]
        public async Task<IActionResult> Add(string id, string returnedId)
        {
            var model = await this.hotelService.LoadCurrentHotelAsync(id ?? returnedId);

            this.ViewBag.Model = model;

            return this.View("~/Views/Cleanings/Add.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCleaningViewModel model, string id)
        {
            await this.cleaningService.CreateAsync(model, id);

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
