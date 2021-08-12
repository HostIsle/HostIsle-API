namespace HostIsle.Data.Models.Hotels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Event
    {
        public Event()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; private set; }

        [Required]
        [MinLength(20)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MinLength(100)]
        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
