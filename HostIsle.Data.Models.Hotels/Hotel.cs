namespace HostIsle.Data.Models.Hotels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Hotel
    {
        public Hotel()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Rooms = new HashSet<Room>();
            this.Reservations = new HashSet<Reservation>();
            this.Events = new HashSet<Event>();
            this.Requests = new HashSet<Request>();
            this.Feedbacks = new HashSet<Feedback>();
            this.HotelRoles = new HashSet<HotelRole>();
            this.UserRoles = new HashSet<ApplicationUserRole>();
        }

        public Hotel(string imageUrl)
            : this()
        {
            this.ImageUrl = imageUrl;
        }

        public string Id { get; private set; }

        [Required]
        [MinLength(10)]
        [MaxLength(100)]
        public string Name { get; set; }

        public string ImageUrl { get; private set; }

        [StringLength(12)]
        public string PhoneNumber { get; set; }

        [Required]
        public string TownId { get; set; }

        public virtual Town Town { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required]
        public int CleaningPeriod { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

        public virtual ICollection<Event> Events { get; set; }

        public virtual ICollection<Request> Requests { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }

        public virtual ICollection<HotelRole> HotelRoles { get; set; }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
