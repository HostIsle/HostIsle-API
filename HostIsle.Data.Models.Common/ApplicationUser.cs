namespace HostIsle.Data.Models.Common
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUser"/> class.
        /// </summary>
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
            this.CleanedRooms = 0;

            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();

            this.Signals = new HashSet<Signal>();
            this.Reservations = new HashSet<Reservation>();
            this.ProceededReservations = new HashSet<Reservation>();
            this.ProcessedSignals = new HashSet<Signal>();
            this.UserRoles = new HashSet<ApplicationUserRole>();
            this.Locations = new HashSet<Location>();
            this.Permissions = new HashSet<Permission>();
            this.Reviews = new HashSet<Review>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public int? CleanedRooms { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<Signal> Signals { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }


        public virtual ICollection<Reservation> ProceededReservations { get; set; }

        public virtual ICollection<Location> Locations { get; set; }

        public virtual ICollection<Signal> ProcessedSignals { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
