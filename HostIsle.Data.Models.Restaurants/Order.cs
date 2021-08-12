using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HostIsle.Data.Models.Restaurants
{
    public class Order
    {
       
        public int Id { get; set; }

        public int TableNumber { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        public DateTime OrderedOn { get; set; }

        public bool IsItConfirmed { get; set; }

        public bool IsFinished { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }


    }
}
