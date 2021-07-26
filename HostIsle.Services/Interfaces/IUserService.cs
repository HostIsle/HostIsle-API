namespace HostIsle.Services.Interfaces
{
    using HostIsle.Web.Hotels.Areas.Manager.ViewModels.Employees;
    using HostIsle.Web.Hotels.ViewModels.User;
    using System.Threading.Tasks;

    public interface IUserService
    {
        public Task<string> UpdateAsync(EditUserViewModel model, string id);

        public Task EditAsync(UserProfileViewModel model);

        public Task ChangePhotoAsync(UserProfileViewModel model);
    }
}
