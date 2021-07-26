namespace HostIsle.Web.Hotels.Services
{
    using System.Threading.Tasks;
    using HostIsle.Data;
    using HostIsle.Data.Models.Hotels;
    using HostIsle.Web.Hotels.Services.Interfaces;
    using Microsoft.AspNetCore.Http;

    public class SignalService : ISignalService
    {
        private readonly IRepository<Feedback> signalRepo;
        private readonly IHttpContextAccessor httpContextAccessor;

        public SignalService(IRepository<Feedback> signalRepo, IHttpContextAccessor httpContextAccessor)
        {
            this.signalRepo = signalRepo;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> DeleteAsync(string id)
        {
            var signalId = id.Split()[0];
            var role = id.Split()[1];

            var signal = await this.signalRepo.GetAsync(signalId);

            var hotelId = signal.HotelId;

            this.signalRepo.Delete(signal);

            await this.signalRepo.SaveChangesAsync();

            return hotelId + " " + role;
        }

        public async Task<string> ProccessAsync(string id)
        {
            var processedByEmployeeId = this.httpContextAccessor.HttpContext.User.FindFirst("Id").Value;

            var signalId = id.Split()[0];
            var role = id.Split()[1];

            var signal = await this.signalRepo.GetAsync(signalId);

            var hotelId = signal.HotelId;

            signal.IsProcessed = true;
            signal.ProcessedByEmployeeId = processedByEmployeeId;

            await this.signalRepo.SaveChangesAsync();

            return hotelId + " " + role;
        }
    }
}
