namespace HostIsle.Data.Models.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Location
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class.
        /// </summary>
        /// <param name="ownerId"></param>
        /// <param name="addressId"></param>
        public Location(string ownerId, string addressId)
        {
            this.Id = Guid.NewGuid().ToString();

            this.OwnerId = ownerId;
            this.AddressId = addressId;

            this.Properties = new HashSet<Property>();
        }

        public string Id { get; set; }

        [Required]
        public string AddressId { get; set; }

        public virtual Address Address { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
}
