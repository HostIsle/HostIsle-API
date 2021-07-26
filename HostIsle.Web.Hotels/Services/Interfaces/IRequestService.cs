namespace HostIsle.Web.Hotels.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HostIsle.Web.Hotels.ViewModels.Hotels;

    public interface IRequestService
    {
        public Task CreateAsync(GetHotelsViewModel model);
    }
}
