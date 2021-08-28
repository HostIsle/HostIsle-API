using System;
using System.Collections.Generic;

namespace HostIsle.Data.Models.Common
{
    using System.ComponentModel.DataAnnotations;

    public class Address
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        /// <param name="description"></param>
        /// <param name="townId"></param>
        public Address(string description, string townId)
        {
            this.Id = Guid.NewGuid().ToString();

            this.Description = description;
            this.TownId = townId;

            this.Locations = new HashSet<Location>();
            this.Properties = new HashSet<Property>();
        }

        public string Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string TownId { get; set; }

        public virtual Town Town { get; set; }

        public virtual ICollection<Location> Locations { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
}
