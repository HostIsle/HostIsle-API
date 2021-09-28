using HostIsle.Data;
using HostIsle.Data.Models.Hotels;
using HostIsle.Data.Models.Restaurants;

namespace HostIsle.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using HostIsle.Services.Interfaces;
    using HostIsle.Web.ViewModels.Property;

    public class PropertyService : IPropertyService
    {
        private readonly IRepository<Hotel> hotelRepo;

        public PropertyService(IRepository<Hotel> hotelRepo, IRepository<Restaurant> restaurantRepo)
        {
            this.hotelRepo = hotelRepo;
        }

        public async Task CreateAsync(CreatePropertyViewModel model)
        {
        }

        public async Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
