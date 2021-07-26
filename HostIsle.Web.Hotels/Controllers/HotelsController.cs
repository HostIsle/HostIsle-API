namespace HostIsle.Web.Hotels.Controllers
{
    using System.Threading.Tasks;
    using HostIsle.Web.Hotels.Services.Interfaces;
    using HostIsle.Web.Hotels.ViewModels.Hotels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class HotelsController : Controller
    {
        private readonly IHotelService hotelService;

        public HotelsController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }

        public IActionResult Add() => this.View();

        [HttpPost]
        public async Task<IActionResult> Create(HotelRegisterViewModel model)
        {
            model.Image = this.Request.Form.Files["image"];

            await this.hotelService.CreateAsync(model);

            return this.Redirect("/Home/Index");
        }
    }
}
