//-----------------------------------------------------------------------
// <copyright file="HotelInformationViewModel.cs" company="HotelCollab">
// Copyright (c) HotelCollab. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using HostIsle.Data.Models.Common;

namespace HostIsle.Web.ViewModels.Hotels
{
    using System.Collections.Generic;
    using HostIsle.Data.Models.Hotels;

    /// <summary>
    /// Keeps the most important information about a hotel.
    /// </summary>
    public class HotelInformationViewModel
    {
        /// <summary>
        /// Gets or sets the current hotel.
        /// </summary>
        public Data.Models.Common.Property Property { get; set; }

        // public List<UserHotelRole> Cleaners { get; set; }

        // public List<UserHotelRole> Receptionists { get; set; }

        public List<Cleaning> Cleanings { get; set; }

        public bool IsManager { get; set; }

        public string Role { get; set; }

        public string UserId { get; set; }

        public HashSet<int> Floors { get; set; }

        public string EmployeeRole { get; set; }

        public HotelReservation Reservation { get; set; }

        public ApplicationUser User { get; set; }

        public ApplicationUser CurrentUser { get; set; }
    }
}
