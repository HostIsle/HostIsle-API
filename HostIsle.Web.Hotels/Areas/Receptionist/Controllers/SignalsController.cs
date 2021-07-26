namespace HostIsle.Web.Hotels.Areas.Receptionist.Controllers
{
    using System.Threading.Tasks;
    using HostIsle.Web.Hotels.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Area("Receptionist")]
    public class SignalsController : Controller
    {
        private readonly IHotelService hotelService;
        private readonly ISignalService signalService;

        public SignalsController(IHotelService hotelService, ISignalService signalService)
        {
            this.hotelService = hotelService;
            this.signalService = signalService;
        }

        [HttpGet]
        public async Task<IActionResult> All(string id, string returnedId) =>
            this.View("~/Views/Signals/All.cshtml", await this.hotelService.LoadCurrentHotelAsync(id == null ? returnedId : id));

        [HttpPost]
        public async Task<IActionResult> Proccess(string id)
        {
            var hotelId = await this.signalService.ProccessAsync(id);

            return this.RedirectToAction("All", "Signals", new { returnedId = hotelId });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var hotelId = await this.signalService.DeleteAsync(id);

            return this.RedirectToAction("All", "Signals", new { returnedId = hotelId });
        }
    }
}
