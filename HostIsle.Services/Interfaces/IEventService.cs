namespace HostIsle.Services.Interfaces
{
    using System.Threading.Tasks;
    using HostIsle.Web.Hotels.ViewModels.Hotels;

    public interface IEventService
    {
        public Task CreateAsync(HotelInformationViewModel model, string id);

        public Task<string> DeleteAsync(string id);
    }
}
