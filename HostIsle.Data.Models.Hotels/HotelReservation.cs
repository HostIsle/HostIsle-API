namespace HostIsle.Data.Models.Hotels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using HostIsle.Data.Models.Common;

    public class HotelReservation : Reservation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HotelReservation"/> class.
        /// </summary>
        /// <param name="servicedById"></param>
        /// <param name="guestId"></param>
        /// <param name="description"></param>
        public HotelReservation(string servicedById, string guestId, string description)
            : base(servicedById, guestId, description)
        {
            this.Signals = new HashSet<Signal>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HotelReservation"/> class.
        /// </summary>
        /// <param name="servicedById"></param>
        /// <param name="guestId"></param>
        /// <param name="description"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="adults"></param>
        /// <param name="children"></param>
        /// <param name="roomId"></param>
        /// <param name="hotelId"></param>
        public HotelReservation(string servicedById, string guestId, string description, DateTime startDate, DateTime endDate, int adults, int children, string roomId, string hotelId)
            : this(servicedById, guestId, description)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Adults = adults;
            this.Children = children;
            this.RoomId = roomId;
        }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int Adults { get; set; }

        [Required]
        public int Children { get; set; }

        [Required]
        public string RoomId { get; set; }

        public virtual Room Room { get; set; }

        public ICollection<Signal> Signals { get; set; }
    }
}