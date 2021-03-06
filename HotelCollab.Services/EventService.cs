using HostIsle.Data.Models.Common;

namespace HostIsle.Services
{
    using System;
    using System.Threading.Tasks;
    using HostIsle.Data;
    using HostIsle.Data.Models.Hotels;
    using HostIsle.Services.Interfaces;
    using HostIsle.Web.ViewModels.Events;

    public class EventService : IEventService
    {
        private readonly IRepository<Event> eventRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventService"/> class.
        /// </summary>
        /// <param name="eventRepo"></param>
        public EventService(IRepository<Event> eventRepo)
        {
            this.eventRepo = eventRepo;
        }

        public async Task CreateAsync(CreateEventViewModel model, string id)
        {
            var date = DateTime.Parse($"{model.Date}T{model.Time}");

            var @event = new Event(model.Title, model.Description, date, id.Split()[0]);

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

            return @event.PropertyId + " " + role;
        }
    }
}
