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

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeesController"/> class.
        /// </summary>
        /// <param name="hotelService"></param>
        /// <param name="userService"></param>
        public EmployeesController(IHotelService hotelService, IUserService userService)
        {
            this.hotelService = hotelService;
            this.userService = userService;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="returnedId"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet]
        public async Task<IActionResult> All(string id, string returnedId)
        {
            var model = await this.hotelService.LoadCurrentHotelAsync(id ?? returnedId);

            this.ViewBag.Model = model;

            return this.View();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet]
        public async Task<IActionResult> Overview(string id)
        {
            var model = await this.hotelService.LoadCurrentHotelAsync(id);

            this.ViewBag.Model = model;

            return this.View();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> Update(EditUserViewModel model, string id)
        {
            var hotelId = await this.userService.UpdateAsync(model, id);

            return this.RedirectToAction("All", "Employees", new { returnedId = hotelId });
        }
    }
}
