namespace HostIsle.Data.Models.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Town
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Town"/> class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="postalCode"></param>
        public Town(string name, string postalCode)
        {
            this.Id = Guid.NewGuid().ToString();

            this.Name = name;
            this.PostalCode = postalCode;

            this.Addresses = new HashSet<Address>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string PostalCode { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
