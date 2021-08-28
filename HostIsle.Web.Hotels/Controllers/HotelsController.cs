namespace HostIsle.Web.Hotels.Controllers
{
    using System.Threading.Tasks;
    using HostIsle.Services.Interfaces;
    using HostIsle.Web.ViewModels.Hotels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class HotelsController : Controller
    {
        private readonly IHotelService hotelService;

        /// <summary>
        /// Initializes a new instance of the <see cref="HotelsController"/> class.
        /// </summary>
        /// <param name="hotelService"></param>
        public HotelsController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }

        public IActionResult Add() => this.View();

        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(HotelRegisterViewModel model)
        {
            model.Image = this.Request.Form.Files["image"];

            await this.hotelService.CreateAsync(model);

            return this.Redirect("/Home/Index");
        }
    }
}
