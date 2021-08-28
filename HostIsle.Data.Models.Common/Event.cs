namespace HostIsle.Data.Models.Common
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Event
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Event"/> class.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="date"></param>
        /// <param name="propertyId"></param>
        public Event(string title, string description, DateTime date, string propertyId)
        {
            this.Id = Guid.NewGuid().ToString();

            this.Title = title;
            this.Description = description;
            this.Date = date;
            this.PropertyId = propertyId;
        }

        public string Id { get; private set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string PropertyId { get; set; }

        public virtual Property Property { get; set; }
    }
}
