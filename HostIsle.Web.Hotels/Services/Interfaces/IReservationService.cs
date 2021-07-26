namespace HostIsle.Web.Hotels.Services.Interfaces
{
    using System.Threading.Tasks;
    using HostIsle.Web.Hotels.ViewModels.Reservations;

    public interface IReservationService
    {
        public Task CreateAsync(AddReservationViewModel model, string id);

        public Task<string> UpdateAsync(EditReservationViewModel model, string id);

        public Task<string> DeleteAsync(string id);

        public Task<string> FreeAsync(string id);
    }
}
