﻿namespace HostIsle.Web.Hotels.Controllers
{
    using System.Threading.Tasks;
    using HostIsle.Services.Interfaces;
    using HostIsle.Web.ViewModels.Hotels;
using HostIsle.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [AutoValidateAntiforgeryToken]
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IRequestService requestService;
        private readonly IHotelService hotelService;
        private readonly IUserService userService;

        public UsersController(IRequestService requestService, IHotelService hotelService, IUserService userService)
        {
            this.requestService = requestService;
            this.hotelService = hotelService;
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Profile(string id, string returnedId) =>
            this.View(await this.hotelService.LoadCurrentHotelAsync(id ?? returnedId));

        [HttpPost]
        public async Task<IActionResult> CreateRequest(GetHotelsViewModel model)
        {
            await this.requestService.CreateAsync(model);

            return this.Redirect("/Home/Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserProfileViewModel model)
        {
            await this.userService.EditAsync(model);

            return this.Redirect("/Home/Index");
        }

        [HttpPost]
        public async Task<IActionResult> ChangePhoto(UserProfileViewModel model)
        {
            await this.userService.ChangePhotoAsync(model);

            return this.Redirect("/Home/Index");
        }
    }
}