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
        private readonly IRepository<Reservation> reservationRepo;
        private readonly IRepository<Feedback> signalRepo;

        public SignalService(IHttpContextAccessor httpContextAccessor, IRepository<Reservation> reservationRepo, IRepository<Feedback> signalRepo)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.reservationRepo = reservationRepo;
            this.signalRepo = signalRepo;
        }

        public async Task<string> CreateAsync(CreateSignalViewModel model, string id)
        {
            var guestId = this.httpContextAccessor.HttpContext.User.FindFirst("Id").Value;

            var reservation = (await this.reservationRepo.GetAllAsync()).FirstOrDefault(res => res.Guest.Id == guestId);
            var signal = new Feedback()
            {
                Title = model.Title,
                Content = model.Description,
                ReservationId = reservation.Id,
                GuestId = reservation.Guest.Id,
                HotelId = reservation.Hotel.Id,
            };

            await this.signalRepo.AddAsync(signal);
            await this.signalRepo.SaveChangesAsync();

            return id;
        }
    }
}
