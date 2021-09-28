namespace HostIsle.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using HostIsle.Web.ViewModels.Locations;

    public interface ILocationService
    {
        public Task CreateAsync(CreateLocationViewModel model);

        public Task DeleteAsync(string id);

        public Task UpdateAsync(string id, CreateLocationViewModel model);
    }
}
