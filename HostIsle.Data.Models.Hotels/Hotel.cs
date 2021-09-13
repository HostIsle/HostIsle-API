namespace HostIsle.Data.Models.Hotels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using HostIsle.Data.Models.Common;
    using HostIsle.Data.Models.Common;

    public class Hotel : Property
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Hotel"/> class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="typeId"></param>
        /// <param name="gallery"></param>
        /// <param name="locationId"></param>
        public Hotel(string phoneNumber, string typeId, string gallery, string locationId)
            : base(phoneNumber, typeId, gallery, locationId)
        {
            this.Rooms = new HashSet<Room>();
        }

        [Required]
        public int CleaningPeriod { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
