using System;
using System.Diagnostics.CodeAnalysis;

namespace HostIsle.Data.Models.Common
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using HostIsle.Data.Models.Common;

    public class Property
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Property"/> class.
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="typeId"></param>
        /// <param name="gallery"></param>
        /// <param name="locationId"></param>
        public Property(string phoneNumber, string typeId, string gallery, string locationId)
        {
            this.Id = Guid.NewGuid().ToString();

            this.PhoneNumber = phoneNumber;
            this.TypeId = typeId;
            this.Gallery = gallery;
            this.LocationId = locationId;

            this.Reservations = new HashSet<Reservation>();
            this.Events = new HashSet<Event>();
            this.Roles = new HashSet<ApplicationRole>();
            this.Reviews = new HashSet<Review>();
            this.UserRoles = new HashSet<ApplicationUserRole>();
            this.Permissions = new HashSet<Permission>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string TypeId { get; set; }

        public virtual PropertyType Type { get; set; }

        public string Gallery { get; set; }

        [Required]
        public string LocationId { get; set; }

        public virtual Location Location { get; set; }

        public virtual ICollection<ApplicationRole> Roles { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

        public virtual ICollection<Event> Events { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
