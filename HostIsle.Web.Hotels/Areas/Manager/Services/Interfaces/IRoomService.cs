namespace HostIsle.Web.Hotels.Areas.Manager.Services.Interfaces
{
    using System.Threading.Tasks;
    using HostIsle.Web.ViewModels.Rooms;

    public interface IRoomService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public Task CreateAsync(RoomRegisterViewModel model, string id);
    }
}
