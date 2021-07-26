namespace HostIsle.Data.Models.Hotels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class HotelRole
    {
        public HotelRole()
        {
            this.Id = Guid.NewGuid().ToString();

            this.UserHotelRoles = new HashSet<UserHotelRole>();
        }

        [Key]
        public string Id { get; set; }

        [ForeignKey("Id")]
        public string HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }

        [ForeignKey("Id")]
        public string RoleId { get; set; }

        public virtual ApplicationRole Role { get; set; }

        public virtual ICollection<UserHotelRole> UserHotelRoles { get; set; }
    }
}
