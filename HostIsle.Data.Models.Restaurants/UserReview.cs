using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostIsle.Data.Models.Restaurants
{
    public class UserReview
    {
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public int ReviewId { get; set; }
        public virtual Review Review { get; set; }

    }
}
