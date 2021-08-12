using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostIsle.Data.Models.Restaurants
{
    public class TypeRestaurant
    {
        public TypeRestaurant(string name)
        {
            this.Name = name;
            this.Restaurants = new HashSet<Restaurant>();
        }
        public TypeRestaurant()
        {
            this.Restaurants = new HashSet<Restaurant>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Restaurant> Restaurants { get; set; }

    }
}
