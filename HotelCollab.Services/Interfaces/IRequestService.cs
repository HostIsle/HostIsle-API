namespace HostIsle.Services.Interfaces
{
    using System.Threading.Tasks;
    using HostIsle.Web.ViewModels.Hotels;

    public interface IRequestService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public Task CreateAsync(GetHotelsViewModel model);
    }
}
