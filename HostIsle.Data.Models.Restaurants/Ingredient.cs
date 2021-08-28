namespace HostIsle.Data.Models.Restaurants
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Ingredient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ingredient"/> class.
        /// </summary>
        /// <param name="name"></param>
        public Ingredient(string name)
        {
            this.Id = Guid.NewGuid().ToString();

            this.Name = name;

            this.ProductIngredients = new HashSet<ProductIngredient>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<ProductIngredient> ProductIngredients { get; set; }
    }
}
