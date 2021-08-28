using System;

namespace HostIsle.Data.Models.Common
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUserRole : IdentityUserRole<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUserRole"/> class.
        /// </summary>
        /// <param name="propertyId"></param>
        public ApplicationUserRole(string propertyId)
        {
            this.Id = Guid.NewGuid().ToString();
            this.PropertyId = propertyId;
        }

        public string Id { get; set; }

        public string PropertyId { get; set; }

        public Property Property { get; set; }
    }
}
