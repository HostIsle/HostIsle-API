namespace HostIsle.Data.Models.Hotels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using HostIsle.Data.Models.Common;
    using HostIsle.Data.Models.Hotels.Enums;

    public class Cleaning
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cleaning"/> class.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="status"></param>
        /// <param name="roomId"></param>
        /// <param name="cleanerId"></param>
        public Cleaning(DateTime date, CleaningStatus status, string roomId, string cleanerId)
        {
            this.Id = Guid.NewGuid().ToString();

            this.Date = date;
            this.Status = status;
            this.RoomId = roomId;
            this.CleanerId = cleanerId;

            this.Damages = new HashSet<Damage>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cleaning"/> class.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="status"></param>
        /// <param name="roomId"></param>
        /// <param name="cleanerId"></param>
        /// <param name="hasDamages"></param>
        public Cleaning(DateTime date, CleaningStatus status, string roomId, string cleanerId, bool hasDamages)
            : this(date, status, roomId, cleanerId)
        {
            this.HasDamages = hasDamages;
        }

        public string Id { get; private set; }

        public DateTime Date { get; set; }

        public CleaningStatus Status { get; set; }

        [Required]
        public string RoomId { get; set; }

        public virtual Room Room { get; set; }

        [Required]
        public string CleanerId { get; set; }

        public virtual ApplicationUser Cleaner { get; set; }

        public bool HasDamages { get; set; }

        public virtual ICollection<Damage> Damages { get; set; }
    }
}
