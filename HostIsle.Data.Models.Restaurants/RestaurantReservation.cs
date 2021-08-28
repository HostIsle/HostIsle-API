namespace HostIsle.Data.Models.Restaurants
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using HostIsle.Data.Models.Common;

    public class RestaurantReservation : Reservation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RestaurantReservation"/> class.
        /// </summary>
        /// <param name="servicedById"></param>
        /// <param name="guestId"></param>
        /// <param name="description"></param>
        /// <param name="date"></param>
        /// <param name="people"></param>
        public RestaurantReservation(string servicedById, string guestId, string description, DateTime date, int people)
            : base(servicedById, guestId, description)
        {
            this.Date = date;
            this.People = people;
        }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int People { get; set; }

        public bool IsReservationFinished { get; set; }
    }
}
