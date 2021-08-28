namespace HostIsle.Data.Models.Hotels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Damage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Damage"/> class.
        /// </summary>
        /// <param name="cleaningId"></param>
        /// <param name="content"></param>
        public Damage(string cleaningId, string content)
        {
            this.Id = Guid.NewGuid().ToString();

            this.CleaningId = cleaningId;
            this.Content = content;
        }

        public string Id { get; private set; }

        [Required]
        public string CleaningId { get; set; }

        public virtual Cleaning Cleaning { get; set; }

        [Required]
        [MaxLength(250)]
        public string Content { get; set; }
    }
}
