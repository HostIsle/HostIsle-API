using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostIsle.Data.Models.Restaurants
{
    public class OrderProduct
    {

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int Amount { get; set; }

        public int Ready { get; set; }

        public int Delivered { get; set; }

    }
}
