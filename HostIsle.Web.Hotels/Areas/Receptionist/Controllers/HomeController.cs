namespace HostIsle.Web.Hotels.Areas.Receptionist.Controllers
{
    using System.Threading.Tasks;
    using HostIsle.Web.Hotels.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Area("Receptionist")]
    public class HomeController : Controller
    {
        private readonly IHotelService hotelService;

        public HomeController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard(string id) =>
            this.View(await this.hotelService.LoadCurrentHotelAsync(id));

        [HttpGet]
        public async Task<IActionResult> Cleanings(string id) =>
            this.View(await this.hotelService.LoadCurrentHotelAsync(id));
    }
}
