using HostIsle.Data.Models.Common;

namespace HostIsle.Web.Hotels.Areas.Guest.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HostIsle.Data;
    using HostIsle.Data.Models.Hotels;
    using HostIsle.Web.Hotels.Areas.Guest.Services.Interfaces;
    using HostIsle.Web.Hotels.Areas.Guest.ViewModels.Signals;
    using Microsoft.AspNetCore.Http;

    public class SignalService : ISignalService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IRepository<HotelReservation> reservationRepo;
        private readonly IRepository<Signal> signalRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignalService"/> class.
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="reservationRepo"></param>
        /// <param name="signalRepo"></param>
        public SignalService(IHttpContextAccessor httpContextAccessor, IRepository<HotelReservation> reservationRepo, IRepository<Signal> signalRepo)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.reservationRepo = reservationRepo;
            this.signalRepo = signalRepo;
        }

        public async Task<string> CreateAsync(CreateSignalViewModel model, string id)
        {
            var guestId = this.httpContextAccessor.HttpContext.User.FindFirst("Id").Value;

            var reservation = (await this.reservationRepo.GetAllAsync()).FirstOrDefault(res => res.Guest.Id == guestId);
            
            var signal = new Signal(model.Title, model.Description, DateTime.UtcNow, reservation?.Id);

            await this.signalRepo.AddAsync(signal);
            await this.signalRepo.SaveChangesAsync();

            return id;
        }
    }
}
