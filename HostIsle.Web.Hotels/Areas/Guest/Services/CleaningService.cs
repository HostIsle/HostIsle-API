namespace HostIsle.Web.Hotels.Areas.Guest.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HostIsle.Data;
    using HostIsle.Data.Models.Hotels;
    using HostIsle.Data.Models.Hotels.Enums;
    using HostIsle.Web.Hotels.Areas.Guest.Services.Interfaces;

    public class CleaningService : ICleaningService
    {
        private readonly IRepository<Cleaning> cleaningRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="CleaningService"/> class.
        /// </summary>
        /// <param name="cleaningRepo"></param>
        public CleaningService(IRepository<Cleaning> cleaningRepo)
        {
            this.cleaningRepo = cleaningRepo;
        }

        public async Task<string> SkipAsync(string id)
        {
            var cleaning = (await this.cleaningRepo.GetAllAsync()).FirstOrDefault(c => c.Date.ToString("dd/MM/yyyy") == DateTime.Now.ToString("dd/MM/yyyy") && c.RoomId == id);

            var hotelId = cleaning.Room.HotelId;

            cleaning.Status = CleaningStatus.Cancelled;

            await this.cleaningRepo.SaveChangesAsync();

            return $"{hotelId} Guest";
        }
    }
}
