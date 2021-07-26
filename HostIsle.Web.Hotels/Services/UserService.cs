namespace HostIsle.Web.Hotels.Services
{
    using System.IO;
    using System.Threading.Tasks;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using HostIsle.Data;
    using HostIsle.Data.Models.Hotels;
    using HostIsle.Web.Hotels.Areas.Manager.ViewModels.Employees;
    using HostIsle.Web.Hotels.Services.Interfaces;
    using HostIsle.Web.Hotels.ViewModels.User;
    using Microsoft.AspNetCore.Http;

    public class UserService : IUserService
    {
        private readonly IRepository<ApplicationUser> userRepo;
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserService(IRepository<ApplicationUser> userRepo, IHttpContextAccessor httpContextAccessor)
        {
            this.userRepo = userRepo;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task EditAsync(UserProfileViewModel model)
        {
            var userId = this.httpContextAccessor.HttpContext.User.FindFirst("id").Value;

            var user = await this.userRepo.GetAsync(userId);

            if (user.FirstName != model.FirstName && model.FirstName != null)
            {
                user.FirstName = model.FirstName;
            }

            if (user.LastName != model.LastName && model.LastName != null)
            {
                user.LastName = model.LastName;
            }

            await this.userRepo.SaveChangesAsync();
        }

        public async Task ChangePhotoAsync(UserProfileViewModel model)
        {
            var imageUrl = string.Empty;

            if (model.Image != null && model.Image.Length > 0)
            {
                var fileName = Path.GetFileName(model.Image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", fileName);

                using var fileStream = new FileStream(filePath, FileMode.Create);

                await model.Image.CopyToAsync(fileStream);

                var account = new Account { ApiKey = "597981955165718", ApiSecret = "YrIRgn7E7ffUnN1kXSJhyGQJS54", Cloud = "hotelcollab" };

                fileStream.Close();

                var cloudinary = new Cloudinary(account);

                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(filePath),
                };

                var result = cloudinary.Upload(uploadParams);

                File.Delete(filePath);

                imageUrl = result.Url.ToString();
            }

            var userId = this.httpContextAccessor.HttpContext.User.FindFirst("id").Value;

            var user = await this.userRepo.GetAsync(userId);

            user.ImageUrl = imageUrl;

            await this.userRepo.SaveChangesAsync();
        }

        public async Task<string> UpdateAsync(EditUserViewModel model, string id)
        {
            var userId = id.Split()[0];
            var hotelId = id.Split()[1];
            var role = id.Split()[2];

            var user = await this.userRepo.GetAsync(userId);

            if (user.FirstName != model.FirstName && model.FirstName != null)
            {
                user.FirstName = model.FirstName;
            }

            if (user.LastName != model.LastName && model.LastName != null)
            {
                user.LastName = model.LastName;
            }

            await this.userRepo.SaveChangesAsync();

            return hotelId + " " + role;
        }
    }
}
