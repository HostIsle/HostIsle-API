namespace HostIsle.Web.Hotels.Services.Interfaces
{
    using System.Threading.Tasks;

    public interface ISignalService
    {
        public Task<string> ProccessAsync(string id);

        public Task<string> DeleteAsync(string id);
    }
}
