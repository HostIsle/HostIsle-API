// <copyright file="CreateCleaningViewModel.cs" company="HotelCollab">
// Copyright (c) HotelCollab. All rights reserved.
// </copyright>

namespace HostIsle.Web.ViewModels.Cleanings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CreateCleaningViewModel
    {
        public string RoomNumber { get; set; }

        public DateTime Date { get; set; }

        public string AssignedTo { get; set; }
    }
}
