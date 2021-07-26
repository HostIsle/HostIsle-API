// <copyright file="HomeController.cs" company="HotelCollab">
// Copyright (c) HotelCollab. All rights reserved.
// </copyright>

namespace HostIsle.Web.Hotels.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using HostIsle.Data;
    using HostIsle.Data.Models.Hotels;
    using HostIsle.Web.Hotels.ViewModels.Hotels;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private readonly IRepository<Hotel> hotelRepo;
        private readonly IRepository<ApplicationUser> userRepo;

        public HomeController(IRepository<Hotel> hotelRepo, IRepository<ApplicationUser> userRepo)
        {
            this.hotelRepo = hotelRepo;
            this.userRepo = userRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var userId = this.User.FindFirst("Id").Value;

                var currentUser = (await this.userRepo.GetAllAsync()).FirstOrDefault(user => user.Id == userId);

                var list = new GetHotelsViewModel();

                list.Hotels = await this.hotelRepo.GetAllAsync();

                foreach (var item in currentUser.UserHotelRoles)
                {
                    var action = string.Empty;

                    if (item.HotelRole.Role.Name == "Manager")
                    {
                        action = "Dashboard";
                    }

                    list.RenderedHotels.Add(new HotelRenderViewModel
                    {
                        Hotel = item.HotelRole.Hotel,
                        Role = item.HotelRole.Role.Name,
                        Action = action,
                    });
                }

                return this.View("Dashboard", list);
            }
            else
            {
                return this.View();
            }
        }
    }
}
