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
        /// <param name="type"></param>
        /// <param name="gallery"></param>
        /// <param name="locationId"></param>
        public Hotel(string name, string phoneNumber, PropertyType type, List<string> gallery, string locationId)
            : base(name, phoneNumber, type, gallery, locationId)
        {
            this.Rooms = new HashSet<Room>();
        }

        [Required]
        public int CleaningPeriod { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
