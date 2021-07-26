namespace HostIsle.Web.Hotels.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HostIsle.Web.Hotels.ViewModels.Hotels;
    using HostIsle.Data.Models.Hotels;

    public interface IHotelService
    {
        public Task CreateAsync(HotelRegisterViewModel model);

        public Task<HotelInformationViewModel> LoadCurrentHotelAsync(string id);

        public Task<List<Hotel>> GetAllAsync();
    }
}
