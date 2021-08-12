// <copyright file="CleaningService.cs" company="HotelCollab">
// Copyright (c) HotelCollab. All rights reserved.
// </copyright>

namespace HostIsle.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HostIsle.Data;
    using HostIsle.Data.Models.Hotels;
    using HostIsle.Data.Models.Hotels.Enums;
    using HostIsle.Services.Interfaces;
    using HostIsle.Web.ViewModels.Cleanings;
    using HostIsle.Web.ViewModels.Rooms;

    public class CleaningService : ICleaningService
    {
        private readonly IRepository<ApplicationUser> userRepo;
        private readonly IRepository<Hotel> hotelRepo;
        private readonly IRepository<Cleaning> cleaningRepo;

        public CleaningService(IRepository<ApplicationUser> userRepo, IRepository<Hotel> hotelRepo, IRepository<Cleaning> cleaningRepo)
        {
            this.userRepo = userRepo;
            this.hotelRepo = hotelRepo;
            this.cleaningRepo = cleaningRepo;
        }

        public async Task<string> AssignAsync(string id)
        {
            var cleaningId = id.Split()[0];
            var cleanerId = id.Split()[1];
            var role = id.Split()[2];
            var cleaning = await this.cleaningRepo.GetAsync(cleaningId);

            cleaning.CleanerId = cleanerId;

            await this.cleaningRepo.SaveChangesAsync();

            return $"{cleaning.Room.HotelId} {role}";
        }

        public async Task<string> CleanAsync(CleanRoomViewModel model, string id)
        {
            var cleaning = await this.cleaningRepo.GetAsync(id);

            var hotelId = cleaning.Room.Hotel.Id;

            cleaning.Status = CleaningStatus.Done;

            cleaning.IsDamaged = model.IsDamaged
                ? true
                : false;

            await this.cleaningRepo.SaveChangesAsync();

            return $"{hotelId} Cleaner";
        }

        public async Task CreateAsync(CreateCleaningViewModel model, string id)
        {
            var hotelId = id.Split()[0];
            var assignTo = await this.userRepo.GetAsync(model.AssignedTo);

            var room = (await this.hotelRepo.GetAsync(hotelId)).Rooms.FirstOrDefault(r => r.RoomNumber == model.RoomNumber);

            var cleaning = new Cleaning()
            {
                Cleaner = assignTo,
                Date = model.Date,
                Room = room,
            };

            await this.cleaningRepo.AddAsync(cleaning);
            await this.cleaningRepo.SaveChangesAsync();
        }
    }
}
