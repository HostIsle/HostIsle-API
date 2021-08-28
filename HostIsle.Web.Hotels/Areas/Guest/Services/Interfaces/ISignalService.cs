namespace HostIsle.Web.Hotels.Areas.Guest.Services.Interfaces
{
    using System.Threading.Tasks;
    using HostIsle.Web.Hotels.Areas.Guest.ViewModels.Signals;

    public interface ISignalService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public Task<string> CreateAsync(CreateSignalViewModel model, string id);
    }
}
