namespace HostIsle.Web.Hotels.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HostIsle.Web.Hotels.Areas.Cleaner.ViewModels;
    using HostIsle.Web.Hotels.ViewModels.Cleanings;

    public interface ICleaningService
    {
        public Task CreateAsync(CreateCleaningViewModel model, string id);

        public Task<string> AssignAsync(string id);

        public Task<string> CleanAsync(CleanRoomViewModel model, string id);
    }
}
