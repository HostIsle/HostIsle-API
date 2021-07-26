namespace HostIsle.Web.Hotels.ViewModels.Hotels
{
    using HostIsle.Data.Models.Hotels;

    public class HotelRenderViewModel
    {
        public Hotel Hotel { get; set; }

        public string Role { get; set; }

        public string Action { get; set; }

        public string HotelId { get; set; }
    }
}
