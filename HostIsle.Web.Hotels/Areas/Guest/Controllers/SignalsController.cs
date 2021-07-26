namespace HostIsle.Web.Hotels.Areas.Guest.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using HostIsle.Web.Hotels.Services.Interfaces;
    using HostIsle.Web.Hotels.ViewModels.Hotels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Area("Guest")]
    public class SignalsController : Controller
    {
        private readonly IHotelService hotelService;
        private readonly Services.Interfaces.ISignalService signalService;

        public SignalsController(IHotelService hotelService, Services.Interfaces.ISignalService signalService)
        {
            this.hotelService = hotelService;
            this.signalService = signalService;
            this.signalService = signalService;
        }

        [HttpGet]
        public async Task<IActionResult> All(string id, string returnedId) =>
            this.View(await this.hotelService.LoadCurrentHotelAsync(id == null ? returnedId : id));

        [HttpPost]
        public async Task<IActionResult> Create(HotelInformationViewModel model, string id)
        {
            var hotelId = await this.signalService.CreateAsync(model.CreateSignalViewModel, id);

            return this.RedirectToAction(
                "All",
                "Signals",
                new { returnedId = hotelId });
        }
    }
}
