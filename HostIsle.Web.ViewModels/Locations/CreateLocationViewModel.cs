using System.ComponentModel.DataAnnotations;

namespace HostIsle.Web.ViewModels.Locations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CreateLocationViewModel
    {
        [Required]
        public string OwnerId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string TownName { get; set; }

        [Required]
        [StringLength(4)]
        public string PostalCode { get; set; }

        [Required]
        [MinLength(20)]
        [MaxLength(500)]
        public string AddressText { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
