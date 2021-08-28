namespace HostIsle.Services.Interfaces
{
    using System.Threading.Tasks;
    using HostIsle.Web.ViewModels.Cleanings;
    using HostIsle.Web.ViewModels.Rooms;

    public interface ICleaningService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public Task CreateAsync(CreateCleaningViewModel model, string id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public Task<string> AssignAsync(string id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public Task<string> CleanAsync(CleanRoomViewModel model, string id);
    }
}
