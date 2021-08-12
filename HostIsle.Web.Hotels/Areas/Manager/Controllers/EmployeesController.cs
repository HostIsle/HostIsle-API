namespace HostIsle.Web.Hotels.Areas.Mananger.Controllers
{
    using System.Threading.Tasks;
    using HostIsle.Services.Interfaces;
    using HostIsle.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Area("Manager")]
    public class EmployeesController : Controller
    {
        private readonly IHotelService hotelService;
        private readonly IUserService userService;

        public EmployeesController(IHotelService hotelService, IUserService userService)
        {
            this.hotelService = hotelService;
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> All(string id, string returnedId)
        {
            var model = await this.hotelService.LoadCurrentHotelAsync(id ?? returnedId);

            this.ViewBag.Model = model;

            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> Overview(string id)
        {
            var model = await this.hotelService.LoadCurrentHotelAsync(id);

            this.ViewBag.Model = model;

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditUserViewModel model, string id)
        {
            var hotelId = await this.userService.UpdateAsync(model, id);

            return this.RedirectToAction("All", "Employees", new { returnedId = hotelId });
        }
    }
}
