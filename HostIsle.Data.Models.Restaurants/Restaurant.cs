using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HostIsle.Data.Models.Restaurants
{
    public class Restaurant
    {
        public Restaurant(string name, string phone, int seats,string workTime,string advantages, TypeRestaurant typeRestaurant, Address address)
        {
            this.Name = name;
            this.Phone = phone;
            this.Seats = seats;
            this.WorkTime = workTime;
            this.Advantages = advantages;
            this.TypeRestaurant = typeRestaurant;
            this.Address = address;
            this.MenuCategories = new HashSet<MenuCategory>();

        }
        public Restaurant()
        {
            this.MenuCategories = new HashSet<MenuCategory>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public string Phone { get; set; }

        [Range(1, int.MaxValue)]
        public int Seats { get; set; }

        public int TypeRestaurantId { get; set; }
        public virtual TypeRestaurant TypeRestaurant { get; set; }

        public string WorkTime { get; set; }

        public string QrCode { get; set; }

        public string Advantages { get; set; }

        public string AdditionalInformation { get; set; }

        public int GaleryImagesCount { get; set; }

        public string IDCard { get; set; }

        public string Lat { get; set; }

        public string Lon { get; set; }

        public string EmployeesId { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<RestaurantCategory> RestaurantCategories { get; set; }

        [Required]
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public bool isRegistrationFinished { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<MenuCategory> MenuCategories { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

    }
}
