namespace HostIsle.Data.Models.Hotels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Damage
    {
        public Damage()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; private set; }

        [Required]
        public string CleaningId { get; set; }

        public virtual Cleaning Cleaning { get; set; }

        [Required]
        [MinLength(20)]
        [MaxLength(250)]
        public string Content { get; set; }
    }
}
