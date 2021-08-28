using System;

namespace HostIsle.Data.Models.Common
{
    using System.ComponentModel.DataAnnotations;

    public class Review
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Review"/> class.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="clientId"></param>
        /// <param name="content"></param>
        /// <param name="propertyId"></param>
        public Review(string title, string clientId, string content, string propertyId)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Date = DateTime.UtcNow;

            this.Title = title;
            this.ClientId = clientId;
            this.Content = content;
            this.PropertyId = propertyId;
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(150)]
        public string Content { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public string ClientId { get; set; }

        public virtual ApplicationUser Client { get; set; }

        [Required]
        public string PropertyId { get; set; }

        public virtual Property Property { get; set; }
    }
}
