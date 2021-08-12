using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostIsle.Data.Models.Restaurants
{
    public class Category
    {
       
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<RestaurantCategory> RestaurantCategories { get; set; }

    }
}
