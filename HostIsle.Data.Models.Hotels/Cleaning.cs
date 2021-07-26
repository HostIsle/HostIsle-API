namespace HostIsle.Data.Models.Hotels
{
    using System;
    using System.Collections.Generic;
    using HostIsle.Data.Models.Hotels.Enums;

    public class Cleaning
    {
        public Cleaning()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Damages = new HashSet<Damage>();
    }

        public string Id { get; private set; }

        public DateTime Date { get; set; }

        public CleaningStatus Status { get; set; }

        public string RoomId { get; set; }

        public virtual Room Room { get; set; }

        public string CleanerId { get; set; }

        public virtual ApplicationUser Cleaner { get; set; }

        public bool IsDamaged { get; set; }

        public virtual ICollection<Damage> Damages { get; set; }
    }
}
