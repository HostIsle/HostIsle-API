namespace HostIsle.Web.Hotels.Areas.Mananger.Controllers
{
    using System.Threading.Tasks;
    using HostIsle.Web.Hotels.Services.Interfaces;
    using HostIsle.Web.Hotels.ViewModels.Hotels;
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
        public async Task<IActionResult> All(string id, string returnedId) =>
            this.View(await this.hotelService.LoadCurrentHotelAsync(id == null ? returnedId : id));

        [HttpGet]
        public async Task<IActionResult> Overview(string id) =>
            this.View(await this.hotelService.LoadCurrentHotelAsync(id));

        [HttpPost]
        public async Task<IActionResult> Update(HotelInformationViewModel model, string id)
        {
            var hotelId = await this.userService.UpdateAsync(model.EditUserViewModel, id);

            return this.RedirectToAction("All", "Employees", new { returnedId = hotelId });
        }
    }
}
