namespace HostIsle.Web.Hotels.ViewModels.Reservations
{
    using System;

    public class EditReservationViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string RoomNumber { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? Adults { get; set; }

        public int? Children { get; set; }
    }
}
