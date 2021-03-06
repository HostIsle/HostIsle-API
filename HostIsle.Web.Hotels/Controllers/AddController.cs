using System.Security.Claims;
using HostIsle.Data.Models.Common;

namespace HostIsle.Web.Hotels.Controllers
{
    using System.Threading.Tasks;
    using HostIsle.Data.Models.Hotels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class AddController : Controller
    {
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddController"/> class.
        /// </summary>
        /// <param name="roleManager"></param>
        /// <param name="signInManager"></param>
        /// <param name="userManager"></param>
        public AddController(RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task<IActionResult> Role()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var roles = new string[5] { "Administrator", "Manager", "Receptionist", "Cleaner", "Guest" };

            foreach (var role in roles)
            {
                await this.roleManager.CreateAsync(new ApplicationRole()
                {
                    Name = role,
                });
            }

            return this.Redirect("/");
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task<IActionResult> Admin()
        {
            var user = new ApplicationUser()
            {
                FirstName = "Администратор",
                LastName = "Администраторов",
                UserName = "admin@admin.admin",
                Email = "admin@admin.admin",
                ImageUrl = "http://res.cloudinary.com/hotelcollab/image/upload/v1616274179/knxs5xmrkouamzn8hzty.jpg",
            };

            var result = await this.userManager.CreateAsync(user, "Admin_123");

            await this.userManager.AddToRoleAsync(user, "Administrator");

            if (result.Succeeded)
            {
                await this.signInManager.SignInAsync(user, isPersistent: false);
                return this.LocalRedirect(this.Url.Content("~/"));
            }

            return this.Redirect("/");
        }
    }
}
