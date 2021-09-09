namespace HostIsle.Services.Interfaces
{
    using System.Threading.Tasks;
    using HostIsle.Web.ViewModels.Locations;

    public interface ILocationService
    {
        public Task CreateAsync(CreateLocationViewModel model);

        public Task DeleteAsync(string id);
    }
}
