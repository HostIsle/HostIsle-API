namespace HostIsle.Data.Models.Hotels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using HostIsle.Data.Models.Hotels.Enums;

    public class Room
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class.
        /// </summary>
        /// <param name="roomNumber"></param>
        /// <param name="description"></param>
        /// <param name="hotelId"></param>
        /// <param name="floors"></param>
        /// <param name="roomType"></param>
        /// <param name="isBusy"></param>
        /// <param name="isCleaned"></param>
        public Room(string roomNumber, string description, string hotelId, int floors, RoomType roomType, bool isBusy, bool isCleaned)
        {
            this.Id = Guid.NewGuid().ToString();

            this.RoomNumber = roomNumber;
            this.HotelId = hotelId;
            this.Floors = floors;
            this.RoomType = roomType;
            this.IsBusy = isBusy;
            this.IsCleaned = isCleaned;
            this.Reservations = new HashSet<HotelReservation>();
            this.Cleanings = new HashSet<Cleaning>();
        }

        public string Id { get; private set; }

        [Required]
        public string RoomNumber { get; set; }

        [Required]
        public string HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }

        [Required]
        public int Floors { get; set; }

        [Required]
        public RoomType RoomType { get; set; }

        public bool IsBusy { get; set; }

        public bool IsCleaned { get; set; }

        public virtual ICollection<HotelReservation> Reservations { get; set; }

        public virtual ICollection<Cleaning> Cleanings { get; set; }
    }
}
