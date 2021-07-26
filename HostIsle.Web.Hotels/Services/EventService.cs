namespace HostIsle.Web.Hotels.Services
{
    using System;
    using System.Threading.Tasks;
    using HostIsle.Data;
    using HostIsle.Data.Models.Hotels;
    using HostIsle.Web.Hotels.Services.Interfaces;
    using HostIsle.Web.Hotels.ViewModels.Hotels;

    public class EventService : IEventService
    {
        private readonly IRepository<Event> eventRepo;

        public EventService(IRepository<Event> eventRepo)
        {
            this.eventRepo = eventRepo;
        }

        public async Task CreateAsync(HotelInformationViewModel model, string id)
        {
            var date = DateTime.Parse($"{model.CreateEventViewModel.Date}T{model.CreateEventViewModel.Time}");

            var @event = new Event()
            {
                Title = model.CreateEventViewModel.Title,
                Date = date,
                Description = model.CreateEventViewModel.Description,
                HotelId = id.Split()[0],
            };

            await this.eventRepo.AddAsync(@event);
            await this.eventRepo.SaveChangesAsync();
        }

        public async Task<string> DeleteAsync(string id)
        {
            var eventId = id.Split()[0];
            var role = id.Split()[1];

            var @event = await this.eventRepo.GetAsync(eventId);

            this.eventRepo.Delete(@event);

            await this.eventRepo.SaveChangesAsync();

            return @event.HotelId + " " + role;
        }
    }
}
