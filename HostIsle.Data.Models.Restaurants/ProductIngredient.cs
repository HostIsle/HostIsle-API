namespace HostIsle.Data.Models.Restaurants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProductIngredient
    {
        public string IngredientId { get; set; }

        public virtual Ingredient Ingredient { get; set; }

        public string ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
