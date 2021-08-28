﻿using System;
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
        /// <param name="name"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="type"></param>
        /// <param name="gallery"></param>
        /// <param name="locationId"></param>
        public Property(string name, string phoneNumber, PropertyType type, List<string> gallery, string locationId)
        {
            this.Id = Guid.NewGuid().ToString();

            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.Type = type;
            this.Gallery = gallery;
            this.LocationId = locationId;

            this.Gallery = new List<string>();
            this.Reservations = new HashSet<Reservation>();
            this.Events = new HashSet<Event>();
            this.Roles = new HashSet<ApplicationRole>();
            this.Reviews = new HashSet<Review>();
            this.UserRoles = new HashSet<ApplicationUserRole>();
            this.Permissions = new HashSet<Permission>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string TypeId { get; set; }

        public PropertyType Type { get; set; }

        public List<string> Gallery { get; private set; }

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