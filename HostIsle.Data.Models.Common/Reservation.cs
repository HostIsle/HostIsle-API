namespace HostIsle.Data.Models.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Reservation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Reservation"/> class.
        /// </summary>
        /// <param name="servicedById"></param>
        /// <param name="guestId"></param>
        /// <param name="description"></param>
        public Reservation(string servicedById, string guestId, string description)
        {
            this.Id = Guid.NewGuid().ToString();
            this.ReservedOn = DateTime.UtcNow;

            this.ServicedById = servicedById;
            this.GuestId = guestId;
            this.Description = description;

            this.Signals = new HashSet<Signal>();
        }

        public string Id { get; private set; }

        public DateTime ReservedOn { get; set; }

        public string Description { get; set; }

        [Required]
        public string ServicedById { get; set; }

        public virtual ApplicationUser ServicedBy { get; set; }

        [Required]
        public string GuestId { get; set; }

        public virtual ApplicationUser Guest { get; set; }

        [Required]
        public string PropertyId { get; set; }

        public virtual Property Property { get; set; }

        public virtual ICollection<Signal> Signals { get; set; }
    }
}
