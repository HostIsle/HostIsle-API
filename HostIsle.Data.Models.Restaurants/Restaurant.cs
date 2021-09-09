namespace HostIsle.Data.Models.Restaurants
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using HostIsle.Data.Models.Common;

    public class Restaurant : Property
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Restaurant"/> class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="type"></param>
        /// <param name="gallery"></param>
        /// <param name="locationId"></param>
        /// <param name="seats"></param>
        /// <param name="workTime"></param>
        public Restaurant(string phoneNumber, PropertyType type, List<string> gallery, string locationId, int seats, string workTime)
            : base(phoneNumber, type, gallery, locationId)
        {
            this.Seats = seats;
            this.WorkTime = workTime;

            this.Products = new HashSet<Product>();
        }

        [Required]
        [Range(1, int.MaxValue)]
        public int Seats { get; set; }

        [Required]
        public string WorkTime { get; set; }

        public string QrCode { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
