namespace HostIsle.Data.Models.Hotels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Feedback
    {
        public Feedback()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Date = DateTime.Now;
            this.IsProcessed = false;
        }

        public string Id { get; private set; }

        [Required]
        public string GuestId { get; set; }

        public virtual ApplicationUser Guest { get; set; }

        [Required]
        [MinLength(20)]
        [MaxLength(50)]
        public string Title { get; set; }

        [MinLength(20)]
        [MaxLength(250)]
        public string Content { get; set; }

        public DateTime Date { get; private set; }

        [Required]
        public string ReservationId { get; set; }

        public virtual Reservation Reservation { get; set; }

        [Required]
        public string HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }

        public string ProcessedByEmployeeId { get; set; }

        public bool IsProcessed { get; set; }

        public virtual ApplicationUser ProcessedByEmployee { get; set; }
    }
}
