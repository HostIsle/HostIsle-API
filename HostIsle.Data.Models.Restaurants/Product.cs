using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HostIsle.Data.Models.Restaurants
{
    public class Product
    {
        public Product(string name, MenuCategory menuCategory,decimal weight,decimal price)
        {
            this.Name = name;
            this.MenuCategoryId = menuCategory.Id;
            this.Weight = weight;
            this.Price = price;

        }
        public Product()
        {

        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string PhotoPath { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Weight { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        public string Description { get; set; }

        public int? MenuCategoryId { get; set; }
        public virtual MenuCategory MenuCategory { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts{ get; set; }

        public virtual ICollection<ProductIngredients> ProductIngredients { get; set; }

    }
}
