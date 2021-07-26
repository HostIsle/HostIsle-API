namespace HostIsle.Web.Hotels.ViewModels.Hotels
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;

    public class HotelRegisterViewModel
    {
        [Required]
        [MinLength(10)]
        [MaxLength(100)]
        public string Name { get; set; }

        [StringLength(12)]
        public string PhoneNumber { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string TownName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required]
        public IFormFile Image { get; set; }

        [Required]
        public int CleaningPeriod { get; set; }
    }
}
