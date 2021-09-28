namespace HostIsle.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using HostIsle.Data;
    using HostIsle.Data.Models.Common;
    using HostIsle.Web.ViewModels.Locations;

    public class LocationService : ILocationService
    {
        private readonly IRepository<Town> townRepo;
        private readonly IRepository<Address> addressRepo;
        private readonly IRepository<Location> locationRepo;

        public LocationService(IRepository<Town> townRepo, IRepository<Address> addressRepo, IRepository<Location> locationRepo)
        {
            this.townRepo = townRepo;
            this.addressRepo = addressRepo;
            this.locationRepo = locationRepo;
        }

        public async Task CreateAsync(CreateLocationViewModel model)
        {
            var addresses = (await this.addressRepo.GetAllAsync())
                .Select(a => a.Description)
                .ToList();

            Address address;

            if (addresses.Contains(model.AddressText))
            {
                address = (await this.addressRepo.GetAllAsync())
                    .FirstOrDefault(a => a.Description == model.AddressText);
            }
            else
            {
                var towns = (await this.townRepo.GetAllAsync())
                    .Select(t => t.Name)
                    .ToList();

                Town town;

                if (towns.Contains(model.TownName))
                {
                    town = (await this.townRepo.GetAllAsync())
                        .FirstOrDefault(t => t.Name == model.TownName);
                }
                else
                {
                    town = new Town(model.TownName, model.PostalCode);

                    await this.townRepo.AddAsync(town);
                    await this.townRepo.SaveChangesAsync();
                }

                address = new Address(model.AddressText, town?.Id);

                await this.addressRepo.AddAsync(address);
                await this.addressRepo.SaveChangesAsync();
            }

            var location = new Location(model.Name, model.OwnerId, address?.Id);

            await this.locationRepo.AddAsync(location);
            await this.locationRepo.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var location = await this.locationRepo.GetAsync(id);

            this.locationRepo.Delete(location);

            await this.locationRepo.SaveChangesAsync();
        }

        public async Task UpdateAsync(string id, CreateLocationViewModel model)
        {

        }
    }
}