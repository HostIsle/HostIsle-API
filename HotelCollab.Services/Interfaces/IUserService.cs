namespace HostIsle.Services.Interfaces
{
    using System.Threading.Tasks;
    using HostIsle.Web.ViewModels.Users;

    public interface IUserService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public Task<string> UpdateAsync(EditUserViewModel model, string id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public Task EditAsync(UserProfileViewModel model);

        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public Task ChangePhotoAsync(UserProfileViewModel model);
    }
}
