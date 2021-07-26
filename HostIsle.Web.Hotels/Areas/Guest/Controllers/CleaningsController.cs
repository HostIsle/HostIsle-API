namespace HostIsle.Web.Hotels.Areas.Guest.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HostIsle.Web.Hotels.Areas.Guest.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Area("Guest")]
    public class CleaningsController : Controller
    {
        private readonly ICleaningService cleaningService;

        public CleaningsController(ICleaningService cleaningService)
        {
            this.cleaningService = cleaningService;
        }

        [HttpPost]
        public async Task<IActionResult> Skip(string id)
        {
            var hotelId = await this.cleaningService.SkipAsync(id);

            return this.RedirectToAction(
                "Dashboard",
                "Home",
                new { returnedId = hotelId });
        }
    }
}
