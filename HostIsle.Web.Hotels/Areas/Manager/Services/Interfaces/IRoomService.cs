namespace HostIsle.Web.Hotels.Areas.Manager.Services.Interfaces
{
    using System.Threading.Tasks;
    using HostIsle.Web.Hotels.ViewModels.Hotels;

    public interface IRoomService
    {
        public Task CreateAsync(HotelInformationViewModel model, string id);
    }
}
