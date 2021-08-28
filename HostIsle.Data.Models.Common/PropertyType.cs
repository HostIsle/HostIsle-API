using System;
using System.Collections.Generic;

namespace HostIsle.Data.Models.Common
{
    using System.ComponentModel.DataAnnotations;

    public class PropertyType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyType"/> class.
        /// </summary>
        /// <param name="name"> The type of the property as text. </param>
        public PropertyType(string name)
        {
            this.Id = Guid.NewGuid().ToString();

            this.Name = name;

            this.Properties = new HashSet<Property>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
}