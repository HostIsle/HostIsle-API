namespace HostIsle.Data.Models.Hotels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Request
    {
        public Request()
        {
            this.Id = Guid.NewGuid().ToString();

            this.CreatedOn = DateTime.Now;
        }

        public string Id { get; private set; }

        public DateTime CreatedOn { get; private set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public string HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
