using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostIsle.Data.Models.Restaurants
{
    public class Address
    {
        public Address(string street, Town town)
        {
            this.Street = street;
            this.Town = town;
        }
        public Address()
        {

        }
        public int Id { get; set; }

        public string Street { get; set; }

        public int TownId { get; set; }
        public virtual Town Town { get; set; }

        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }

    }
}
