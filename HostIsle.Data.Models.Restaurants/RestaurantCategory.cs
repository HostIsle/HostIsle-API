using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostIsle.Data.Models.Restaurants
{
    public class RestaurantCategory
    {

        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
