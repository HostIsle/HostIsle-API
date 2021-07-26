namespace HostIsle.Data.Models.Hotels
{
    using System;

    public class UserHotelRole
    {
        public UserHotelRole()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string HotelRoleId { get; set; }

        public virtual HotelRole HotelRole { get; set; }
    }
}
