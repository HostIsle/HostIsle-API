namespace HostIsle.Data.Models.Restaurants
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Threading.Tasks;
    using HostIsle.Data.Models.Restaurants.Enums;

    public class Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="weight"></param>
        /// <param name="price"></param>
        /// <param name="restaurantId"></param>
        public Product(string name, decimal weight, decimal price, string restaurantId)
        {
            this.Id = Guid.NewGuid().ToString();

            this.Name = name;
            this.Weight = weight;
            this.Price = price;
            this.RestaurantId = restaurantId;

            this.ProductIngredients = new HashSet<ProductIngredient>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="imageUrl"></param>
        /// <param name="weight"></param>
        /// <param name="price"></param>
        /// <param name="description"></param>
        /// <param name="restaurantId"></param>
        public Product(string name, string imageUrl, decimal weight, decimal price, string description, string restaurantId)
            : this(name, weight, price, restaurantId)
        {
            this.ImageUrl = imageUrl;
            this.Description = description;
        }

        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public decimal Weight { get; set; }

        [Required]
        public decimal Price { get; set; }

        public ProductType Type { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }

        [Required]
        public string RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        public virtual ICollection<ProductIngredient> ProductIngredients { get; set; }
    }
}
