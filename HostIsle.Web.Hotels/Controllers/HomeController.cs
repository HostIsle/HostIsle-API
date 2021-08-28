// <copyright file="HomeController.cs" company="HotelCollab">
// Copyright (c) HotelCollab. All rights reserved.
// </copyright>

namespace HostIsle.Web.Hotels.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using HostIsle.Data;
    using HostIsle.Data.Models.Hotels;
    using HostIsle.Web.ViewModels.Hotels;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private readonly IRepository<Hotel> hotelRepo;
        private readonly IRepository<ApplicationUser> userRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="hotelRepo"></param>
        /// <param name="userRepo"></param>
        public HomeController(IRepository<Hotel> hotelRepo, IRepository<ApplicationUser> userRepo)
        {
            this.hotelRepo = hotelRepo;
            this.userRepo = userRepo;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var currentUser = (await this.userRepo.GetAllAsync()).FirstOrDefault(user => user.UserName == this.User.Identity.Name);

                var list = new GetHotelsViewModel();

                list.Hotels = await this.hotelRepo.GetAllAsync();

                foreach (var item in currentUser.UserHotelRoles)
                {
                    list.RenderedHotels.Add(new HotelRenderViewModel
                    {
                        Hotel = item.HotelRole.Hotel,
                        Role = item.HotelRole.Role.Name,
                    });
                }

                this.ViewBag.UserHotels = list.RenderedHotels;
                this.ViewBag.Hotels = list.Hotels;
                this.ViewBag.CurrentUser = currentUser;

                return this.View("Dashboard");
            }
            else
            {
                return this.View();
            }
        }
    }
}
