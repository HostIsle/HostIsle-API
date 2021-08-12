namespace HostIsle.Data.Models.Hotels
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public string HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
