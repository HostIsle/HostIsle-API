namespace HostIsle.Web.Hotels.Areas.Guest.Controllers
{
    using System.Threading.Tasks;
    using HostIsle.Web.Hotels.Services.Interfaces;
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
        public async Task<IActionResult> Dashboard(string id, string returnedId) =>
            this.View(await this.hotelService.LoadCurrentHotelAsync(id == null ? returnedId : id));

        [HttpGet]
        public async Task<IActionResult> Signal(string id)
            => this.View(await this.hotelService.LoadCurrentHotelAsync(id));
    }
}
