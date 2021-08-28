namespace HostIsle.Data.Models.Restaurants
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Threading.Tasks;
    using HostIsle.Data.Models.Common;
    using HostIsle.Data.Models.Restaurants.Enums;

    public class Order
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        /// <param name="tableNumber"></param>
        /// <param name="clientId"></param>
        /// <param name="restaurantId"></param>
        /// <param name="totalPrice"></param>
        public Order(int tableNumber, string clientId, string restaurantId, decimal totalPrice)
        {
            this.Id = Guid.NewGuid().ToString();
            this.OrderedOn = DateTime.UtcNow;
            this.State = OrderState.Waiting;

            this.TableNumber = tableNumber;
            this.ClientId = clientId;
            this.RestaurantId = restaurantId;
            this.TotalPrice = totalPrice;

            this.Products = new Dictionary<Product, int>();
            this.ProductsState = new Dictionary<Product, ProductState>();
        }

        public string Id { get; set; }

        [Required]
        public int TableNumber { get; set; }

        [Required]
        public string ClientId { get; set; }

        public virtual ApplicationUser Client { get; set; }

        [Required]
        public string RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime OrderedOn { get; set; }

        public OrderState State { get; set; }

        public virtual IDictionary<Product, int> Products { get; set; }

        public virtual IDictionary<Product, ProductState> ProductsState { get; set; }
    }
}
