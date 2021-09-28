using HostIsle.Data.Models.Common;

namespace HostIsle.Services
{
    using System.Threading.Tasks;
    using HostIsle.Data;
    using HostIsle.Data.Models.Hotels;
    using HostIsle.Services.Interfaces;
    using Microsoft.AspNetCore.Http;

    public class SignalService : ISignalService
    {
        private readonly IRepository<Signal> signalRepo;
        private readonly IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignalService"/> class.
        /// </summary>
        /// <param name="signalRepo"></param>
        /// <param name="httpContextAccessor"></param>
        public SignalService(IRepository<Signal> signalRepo, IHttpContextAccessor httpContextAccessor)
        {
            this.signalRepo = signalRepo;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> DeleteAsync(string id)
        {
            var signalId = id.Split()[0];
            var role = id.Split()[1];

            var signal = await this.signalRepo.GetAsync(signalId);

            var hotelId = signal.Reservation.PropertyId;

            this.signalRepo.Delete(signal);

            await this.signalRepo.SaveChangesAsync();

            return hotelId + " " + role;
        }

        public async Task<string> ProccessAsync(string id)
        {
            var processedByEmployeeId = this.httpContextAccessor.HttpContext.User.FindFirst("Id")?.Value;

            var signalId = id.Split()[0];
            var role = id.Split()[1];

            var signal = await this.signalRepo.GetAsync(signalId);

            var hotelId = signal.Reservation.PropertyId;

            signal.IsProcessed = true;
            signal.ProcessedByEmployeeId = processedByEmployeeId;

            await this.signalRepo.SaveChangesAsync();

            return hotelId + " " + role;
        }
    }
}
