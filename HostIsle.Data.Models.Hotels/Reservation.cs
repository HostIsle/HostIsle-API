namespace HostIsle.Data.Models.Hotels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Reservation
    {
        public Reservation()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Feedbacks = new HashSet<Feedback>();
        }

        public string Id { get; private set; }

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

        [Required]
        public string HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }

        [Required]
        public string ReceptionistId { get; set; }

        public virtual ApplicationUser Receptionist { get; set; }

        [Required]
        public string GuestId { get; set; }

        public virtual ApplicationUser Guest { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
