using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostIsle.Data.Models.Restaurants
{
    public class MenuCategory
    {

        public MenuCategory(string name, Restaurant restaurant)
        {
            this.Name = name;
            this.RestaurantId = restaurant.Id;
            this.Products = new HashSet<Product>();
        }
        public MenuCategory()
        {
            this.Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
