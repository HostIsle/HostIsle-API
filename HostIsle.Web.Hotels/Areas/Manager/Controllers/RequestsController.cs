namespace HostIsle.Web.Hotels.Areas.Mananger.Controllers
{
    using System.Threading.Tasks;
    using HostIsle.Web.Hotels.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Area("Manager")]
    public class RequestsController : Controller
    {
        private readonly HostIsle.Services.Interfaces.IRequestService requestService;
        private readonly IHotelService hotelService;

        public RequestsController(Services.Interfaces.IRequestService requestService, IHotelService hotelService)
        {
            this.requestService = requestService;
            this.hotelService = hotelService;
        }

        [HttpGet]
        public async Task<IActionResult> All(string id, string returnedId) =>
            this.View(await this.hotelService.LoadCurrentHotelAsync(id == null ? returnedId : id));

        [HttpPost]
        public async Task<IActionResult> Accept(string id) =>
            this.RedirectToAction(
                "All",
                "Requests",
                new { returnedId = await this.requestService.AcceptAsync(id) });

        [HttpPost]
        public async Task<IActionResult> Delete(string id) =>
            this.RedirectToAction(
                "All",
                "Requests",
                new { returnedId = await this.requestService.DeleteAsync(id) });
    }
}
