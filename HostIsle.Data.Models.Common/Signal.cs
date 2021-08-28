namespace HostIsle.Data.Models.Common
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using HostIsle.Data.Models.Common;

    public class Signal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Signal"/> class.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <param name="date"></param>
        /// <param name="reservationId"></param>
        public Signal(string title, string content, DateTime date, string reservationId)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Date = DateTime.UtcNow;
        }

        public string Id { get; private set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(250)]
        public string Content { get; set; }

        public DateTime Date { get; private set; }

        [Required]
        public string ReservationId { get; set; }

        public virtual Reservation Reservation { get; set; }

        public string ProcessedByEmployeeId { get; set; }

        public virtual ApplicationUser ProcessedByEmployee { get; set; }

        public bool IsProcessed { get; set; }
    }
}
