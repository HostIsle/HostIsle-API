namespace HostIsle.Services.Interfaces
{
    using HostIsle.Web.ViewModels.Reservations;
    using System.Threading.Tasks;

    public interface IReservationService
    {
        public Task CreateAsync(AddReservationViewModel model, string id);

        public Task<string> UpdateAsync(EditReservationViewModel model, string id);

        public Task<string> DeleteAsync(string id);

        public Task<string> FreeAsync(string id);
    }
}
