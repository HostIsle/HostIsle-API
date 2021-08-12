using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostIsle.Data.Models.Restaurants
{
    public class Review
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public bool Recommended { get; set; }

        public string Comment { get; set; }

        public DateTime CommentedOn { get; set; }

        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        public virtual ICollection<UserReview> UserReviews { get; set; }



    }
}
