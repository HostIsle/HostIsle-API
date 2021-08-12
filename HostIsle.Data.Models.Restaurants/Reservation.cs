using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostIsle.Data.Models.Restaurants
{
    public class Reservation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Comment { get; set; }

        public DateTime ReservedOn { get; set; }

        public int PeopleCount { get; set; }

        public bool IsReservationFinished { get; set; }

        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        public DateTime DateTime { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

    }
}
