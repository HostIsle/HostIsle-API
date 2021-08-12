namespace HostIsle.Services.Interfaces
{
    using System.Threading.Tasks;
    using HostIsle.Web.ViewModels.Hotels;

    public interface IRequestService
    {
        public Task CreateAsync(GetHotelsViewModel model);
    }
}
