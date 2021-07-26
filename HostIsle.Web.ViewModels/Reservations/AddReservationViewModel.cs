namespace HostIsle.Web.Hotels.ViewModels.Reservations
{
    public class AddReservationViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string Email { get; set; }

        public string RoomNumber { get; set; }

        public int Adults { get; set; }

        public int Children { get; set; }
    }
}
