namespace HostIsle.Web.Hotels.Services.Interfaces
{
    using System.Threading.Tasks;
    using HostIsle.Web.Hotels.Areas.Manager.ViewModels.Employees;
    using HostIsle.Web.Hotels.ViewModels.User;

    public interface IUserService
    {
        public Task<string> UpdateAsync(EditUserViewModel model, string id);

        public Task EditAsync(UserProfileViewModel model);

        public Task ChangePhotoAsync(UserProfileViewModel model);
    }
}
