namespace HostIsle.Web.ViewModels.Rooms
{
    using HostIsle.Data.Models.Hotels.Enums;

    public class RoomRegisterViewModel
    {
        public string RoomNumber { get; set; }

        public RoomType Type { get; set; }

        public int Floor { get; set; }
    }
}
