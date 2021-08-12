namespace HostIsle.Web.Hotels.Areas.Manager.Services.Interfaces
{
    using HostIsle.Web.ViewModels.Rooms;
    using System.Threading.Tasks;

    public interface IRoomService
    {
        public Task CreateAsync(RoomRegisterViewModel model, string id);
    }
}
