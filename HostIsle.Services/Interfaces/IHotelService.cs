namespace HostIsle.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HostIsle.Data.Models.Hotels;
    using HostIsle.Web.ViewModels.Hotels;

    public interface IHotelService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public Task CreateAsync(HotelRegisterViewModel model);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public Task<HotelInformationViewModel> LoadCurrentHotelAsync(string id);

        /// <summary>
        ///
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public Task<List<Hotel>> GetAllAsync();
    }
}
