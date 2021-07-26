namespace HostIsle.Web.Hotels.Areas.Guest.Services.Interfaces
{
    using System.Threading.Tasks;

    public interface ICleaningService
    {
        public Task<string> SkipAsync(string id);
    }
}
