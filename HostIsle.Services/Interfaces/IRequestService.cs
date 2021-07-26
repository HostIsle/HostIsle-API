namespace HostIsle.Services.Interfaces
{
    using System.Threading.Tasks;
    using HostIsle.Web.Hotels.ViewModels.Hotels;

    public interface IRequestService
    {
        public Task CreateAsync(GetHotelsViewModel model);
    }
}
