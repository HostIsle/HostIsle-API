namespace HostIsle.Web.Hotels.Areas.Guest.Services.Interfaces
{
    using HostIsle.Web.Hotels.Areas.Guest.ViewModels.Signals;
    using System.Threading.Tasks;

    public interface ISignalService
    {
        public Task<string> CreateAsync(CreateSignalViewModel model, string id);
    }
}
