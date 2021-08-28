// ReSharper disable VirtualMemberCallInConstructor
namespace HostIsle.Data.Models.Common
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationRole : IdentityRole
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationRole"/> class.
        /// </summary>
        public ApplicationRole()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationRole"/> class.
        /// </summary>
        /// <param name="name"></param>
        public ApplicationRole(string name)
            : base(name)
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;

            this.UserRoles = new HashSet<ApplicationUserRole>();
            this.Permissions = new HashSet<Permission>();
        }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
