namespace HostIsle.Services.Interfaces
{
    using HostIsle.Web.ViewModels.Events;
    using System.Threading.Tasks;

    public interface IEventService
    {
        public Task CreateAsync(CreateEventViewModel model, string id);

        public Task<string> DeleteAsync(string id);
    }
}
