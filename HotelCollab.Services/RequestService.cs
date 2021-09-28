namespace HostIsle.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HostIsle.Data;
    using HostIsle.Data.Models.Hotels;
    using HostIsle.Services.Interfaces;
    using HostIsle.Web.ViewModels.Hotels;
    using Microsoft.AspNetCore.Http;

    public class RequestService : IRequestService
    {
        private readonly IRepository<Hotel> hotelRepo;
        private readonly IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestService"/> class.
        /// </summary>
        /// <param name="requestRepo"></param>
        /// <param name="hotelRepo"></param>
        /// <param name="httpContextAccessor"></param>
        public RequestService(IRepository<Hotel> hotelRepo, IHttpContextAccessor httpContextAccessor)
        {
            this.hotelRepo = hotelRepo;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateAsync(GetHotelsViewModel model)
        {
            //model.Hotels = await this.hotelRepo.GetAllAsync();

            //var request = new Request()
            //{
            //    Role = model.Role,
            //    Hotel = model.Hotels.Where(h => h.Id == model.HotelId).FirstOrDefault(),
            //    UserId = this.httpContextAccessor.HttpContext.User.FindFirst("Id").Value,
            //};

            //await this.requestRepo.AddAsync(request);
            //await this.requestRepo.SaveChangesAsync();

        }
    }
}
