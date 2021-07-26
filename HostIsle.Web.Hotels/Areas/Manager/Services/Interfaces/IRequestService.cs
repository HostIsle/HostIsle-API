namespace HostIsle.Web.Hotels.Areas.Manager.Services.Interfaces
{
    using System.Threading.Tasks;

    public interface IRequestService
    {
        public Task<string> AcceptAsync(string id);

        public Task<string> DeleteAsync(string id);
    }
}
