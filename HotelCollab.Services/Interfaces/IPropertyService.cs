using HostIsle.Web.ViewModels.Property;

namespace HostIsle.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPropertyService
    {
        public Task CreateAsync(CreatePropertyViewModel model);

        public Task DeleteAsync(string id);
    }
}
