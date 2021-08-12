namespace HostIsle.Services.Interfaces
{
    using System.Threading.Tasks;
    using HostIsle.Web.ViewModels.Cleanings;
    using HostIsle.Web.ViewModels.Rooms;

    public interface ICleaningService
    {
        public Task CreateAsync(CreateCleaningViewModel model, string id);

        public Task<string> AssignAsync(string id);

        public Task<string> CleanAsync(CleanRoomViewModel model, string id);
    }
}
