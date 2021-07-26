//-----------------------------------------------------------------------
// <copyright file="HotelInformationViewModel.cs" company="HotelCollab">
// Copyright (c) HotelCollab. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace HostIsle.Web.Hotels.ViewModels.Hotels
{
    using System.Collections.Generic;
    using HostIsle.Web.Hotels.Areas.Cleaner.ViewModels;
    using HostIsle.Web.Hotels.Areas.Guest.ViewModels.Signals;
    using HostIsle.Web.Hotels.Areas.Manager.ViewModels;
    using HostIsle.Web.Hotels.Areas.Manager.ViewModels.Employees;
    using HostIsle.Web.Hotels.Areas.Manager.ViewModels.Room;
    using HostIsle.Web.Hotels.ViewModels.Cleanings;
    using HostIsle.Web.Hotels.ViewModels.Reservations;
    using HostIsle.Web.Hotels.ViewModels.User;
    using HostIsle.Data.Models.Hotels;

    /// <summary>
    /// Keeps the most important information about a hotel.
    /// </summary>
    public class HotelInformationViewModel
    {
        /// <summary>
        /// Gets or sets the current hotel.
        /// </summary>
        public Hotel Hotel { get; set; }

        public List<UserHotelRole> Cleaners { get; set; }

        public List<UserHotelRole> Receptionists { get; set; }

        public List<Cleaning> Cleanings { get; set; }

        public bool IsManager { get; set; }

        public string Role { get; set; }

        public string UserId { get; set; }

        public HashSet<int> Floors { get; set; }

        public string EmployeeRole { get; set; }

        public Reservation Reservation { get; set; }

        public ApplicationUser User { get; set; }

        public ApplicationUser CurrentUser { get; set; }

        public AddReservationViewModel AddReservationViewModel { get; set; }

        public RoomRegisterViewModel RoomRegisterViewModel { get; set; }

        public CreateEventViewModel CreateEventViewModel { get; set; }

        public CreateSignalViewModel CreateSignalViewModel { get; set; }

        public EditUserViewModel EditUserViewModel { get; set; }

        public EditReservationViewModel EditReservationViewModel { get; set; }

        public CreateCleaningViewModel CreateCleaningViewModel { get; set; }

        public CleanRoomViewModel CleanRoomViewModel { get; set; }

        public UserProfileViewModel UserProfileViewModel { get; set; }
    }
}
