namespace HostIsle.Web.Hotels.Areas.Guest.Controllers
{
    using System.Threading.Tasks;
    using HostIsle.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Area("Guest")]
    public class HomeController : Controller
    {
        private readonly IHotelService hotelService;

        public HomeController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard(string id, string returnedId)
        {
            var model = await this.hotelService.LoadCurrentHotelAsync(id ?? returnedId);

            this.ViewBag.Model = model;

            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> Signal(string id)
        {
            var model = await this.hotelService.LoadCurrentHotelAsync(id);

            this.ViewBag.Model = model;

            return this.View();
        }
    }
}
