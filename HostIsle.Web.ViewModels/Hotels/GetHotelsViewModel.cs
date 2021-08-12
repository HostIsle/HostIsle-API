namespace HostIsle.Web.ViewModels.Hotels
{
    using System.Collections.Generic;
    using HostIsle.Data.Models.Hotels;

    public class GetHotelsViewModel
    {
        public GetHotelsViewModel()
        {
            this.RenderedHotels = new List<HotelRenderViewModel>();
            this.Hotels = new List<Hotel>();
        }

        public List<Hotel> Hotels { get; set; }

        public string HotelId { get; set; }

        public string Role { get; set; }

        public List<HotelRenderViewModel> RenderedHotels { get; set; }
    }
}
