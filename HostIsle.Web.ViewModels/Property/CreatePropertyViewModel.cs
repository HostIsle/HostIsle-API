using System.ComponentModel.DataAnnotations;

namespace HostIsle.Web.ViewModels.Property
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CreatePropertyViewModel
    {
        [Required]
        [MinLength(20)]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Type { get; set; }
    }
}
