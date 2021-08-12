// <copyright file="ReservationService.cs" company="HotelCollab">
// Copyright (c) HotelCollab. All rights reserved.
// </copyright>

namespace HostIsle.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using HostIsle.Data;
    using HostIsle.Data.Models.Hotels;
    using HostIsle.Data.Models.Hotels.Enums;
    using HostIsle.Services.Interfaces;
    using HostIsle.Web.ViewModels.Reservations;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;

    /// <summary>
    /// Methods for controlling the reservations.
    /// </summary>
    public class ReservationService : IReservationService
    {
        private readonly IRepository<Feedback> feedbackRepo;
        private readonly IRepository<Cleaning> cleaningRepo;
        private readonly IRepository<Hotel> hotelRepo;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IRepository<ApplicationUser> userRepo;
        private readonly IRepository<UserHotelRole> userHotelRoleRepo;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRepository<Reservation> reservationRepo;
        private readonly IRepository<Room> roomRepo;
        private readonly IRepository<HotelRole> hotelRoleRepo;

        private string role;
        private string hotelId;
        private string reservationId;
        private AddReservationViewModel addReservationViewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReservationService"/> class.
        /// </summary>
        /// <param name="feedbackRepo"> Access the feedbacks table of the database. </param>
        /// <param name="cleaningRepo"> Access the cleanings table of the database. </param>
        /// <param name="hotelRepo"> Access the hotels table of the database. </param>
        /// <param name="httpContextAccessor"> Access the current session information. </param>
        /// <param name="userRepo"> Access the users table of the database. </param>
        /// <param name="userHotelRoleRepo"> Access the userHotelRoles table of the database. </param>
        /// <param name="userManager"> Access the ASP.NET user manager. </param>
        /// <param name="reservationRepo"> Access the reservations table of the database. </param>
        /// <param name="roomRepo"> Access the rooms table of the database. </param>
        /// <param name="hotelRoleRepo"> Access the hotelRoles table of the database. </param>
        public ReservationService(IRepository<Feedback> feedbackRepo, IRepository<Cleaning> cleaningRepo, IRepository<Hotel> hotelRepo, IHttpContextAccessor httpContextAccessor, IRepository<ApplicationUser> userRepo, IRepository<UserHotelRole> userHotelRoleRepo, UserManager<ApplicationUser> userManager, IRepository<Reservation> reservationRepo, IRepository<Room> roomRepo, IRepository<HotelRole> hotelRoleRepo)
        {
            this.feedbackRepo = feedbackRepo;
            this.cleaningRepo = cleaningRepo;
            this.hotelRepo = hotelRepo;
            this.httpContextAccessor = httpContextAccessor;
            this.userRepo = userRepo;
            this.userHotelRoleRepo = userHotelRoleRepo;
            this.userManager = userManager;
            this.reservationRepo = reservationRepo;
            this.roomRepo = roomRepo;
            this.hotelRoleRepo = hotelRoleRepo;
        }

        /// <summary>
        /// Creates a new reservation in the database.
        /// </summary>
        /// <param name="model"> Information about the reservation. </param>
        /// <param name="id"> Holds all the needed ids. </param>
        /// <returns> It is a void method. </returns>
        public async Task CreateAsync(AddReservationViewModel model, string id)
        {
            this.addReservationViewModel = model;
            this.hotelId = id.Split()[0];

            var guest = await this.IsTheGuestRegisteredBeforeAsync()
                ? await this.GetUserProfileAsync()
                : await this.CreateNewUserProfileAsync();

            await this.AddGuestToRoleAsync(guest);

            await this.CreateReservationAsync(guest);
        }

        /// <summary>
        /// Delete reservation by given id.
        /// </summary>
        /// <param name="id">Id of the reservation we want to delete.</param>
        /// <returns> Returns the hotel's id and current user's role. </returns>
        public async Task<string> DeleteAsync(string id)
        {
            this.reservationId = id.Split()[0];
            this.role = id.Split()[1];

            var reservation = await this.GetReservationAsync();

            this.DeleteSignalsOfReservation(reservation);

            await this.DeleteReservationAsync(reservation);

            return reservation.HotelId + " " + this.role;
        }

        /// <summary>
        /// Free the room of the reservation on leaving.
        /// </summary>
        /// <param name="id"> The id of the room. </param>
        /// <returns> The id of the hotel. </returns>
        public async Task<string> FreeAsync(string id)
        {
            var role = id.Split()[0];
            var reservationId = id.Split()[1];

            var reservation = await this.reservationRepo.GetAsync(reservationId);

            var room = reservation.Room;

            room.IsBusy = false;

            await this.roomRepo.SaveChangesAsync();

            var hotelId = reservation.HotelId;

            var hotelRole = (await this.hotelRoleRepo.GetAllAsync()).FirstOrDefault(hr => hr.Role.Name == "Guest");

            var userHotelRole = (await this.userHotelRoleRepo.GetAllAsync()).FirstOrDefault(uhr => uhr.User.Id == reservation.Guest.Id && uhr.HotelRole == hotelRole);

            this.userHotelRoleRepo.Delete(userHotelRole);
            await this.userHotelRoleRepo.SaveChangesAsync();

            return $"{hotelId} {role}";
        }

        /// <summary>
        /// Change the details on given reservation.
        /// </summary>
        /// <param name="model"> The updated information about the reservation. </param>
        /// <param name="id">The id of the reservation. </param>
        /// <returns> The id of the hotel. </returns>
        public async Task<string> UpdateAsync(EditReservationViewModel model, string id)
        {
            var hotelId = id.Split()[0];
            var role = id.Split()[1];
            var reservationId = id.Split()[2];

            var reservation = await this.reservationRepo.GetAsync(reservationId);

            if (reservation.Guest.FirstName != model.FirstName && model.FirstName != null)
            {
                reservation.Guest.FirstName = model.FirstName;
            }

            if (reservation.Guest.LastName != model.LastName && model.LastName != null)
            {
                reservation.Guest.LastName = model.LastName;
            }

            if (reservation.Guest.Email != model.Email && model.Email != null)
            {
                reservation.Guest.Email = model.Email;
            }

            if (reservation.Room.RoomNumber != model.RoomNumber && model.RoomNumber != null)
            {
                reservation.Room = (await this.roomRepo.GetAllAsync()).FirstOrDefault(room => room.RoomNumber == model.RoomNumber);
            }

            if (reservation.StartDate != model.StartDate && model.StartDate != null)
            {
                reservation.StartDate = (DateTime)model.StartDate;
            }

            if (reservation.EndDate != model.EndDate && model.EndDate != null)
            {
                reservation.EndDate = (DateTime)model.EndDate;
            }

            if (reservation.Adults != model.Adults && model.Adults != null)
            {
                reservation.Adults = (int)model.Adults;
            }

            if (reservation.Children != model.Children && model.Children != null)
            {
                reservation.Children = (int)model.Children;
            }

            await this.reservationRepo.SaveChangesAsync();

            return hotelId + " " + role;
        }

        private async Task CreateReservationAsync(ApplicationUser guest)
        {
            var room = (await this.roomRepo.GetAllAsync())
                .FirstOrDefault(room => room.RoomNumber == this.addReservationViewModel.RoomNumber);

            room.IsBusy = true;

            await this.roomRepo.SaveChangesAsync();

            var receptionistName = this.httpContextAccessor.HttpContext.User.Identity.Name;

            var receptionistId = (await this.userRepo.GetAllAsync()).FirstOrDefault(user => user.UserName == receptionistName).Id;

            var reservation = new Reservation()
            {
                GuestId = guest.Id,
                StartDate = DateTime.Parse(this.addReservationViewModel.StartDate),
                EndDate = DateTime.Parse(this.addReservationViewModel.EndDate),
                Adults = this.addReservationViewModel.Adults,
                Children = this.addReservationViewModel.Children,
                RoomId = room.Id,
                HotelId = this.hotelId,
                ReceptionistId = receptionistId,
            };

            var hotel = await this.hotelRepo.GetAsync(this.hotelId);

            for (DateTime i = reservation.StartDate.AddDays(hotel.CleaningPeriod); i < reservation.EndDate; i = i.AddDays(hotel.CleaningPeriod))
            {
                var cleaning = new Cleaning()
                {
                    RoomId = reservation.RoomId,
                    Date = i,
                    Status = CleaningStatus.Upcoming,
                };

                await this.cleaningRepo.AddAsync(cleaning);
            }

            await this.cleaningRepo.SaveChangesAsync();

            await this.reservationRepo.AddAsync(reservation);
            await this.reservationRepo.SaveChangesAsync();
        }

        private async Task AddGuestToRoleAsync(ApplicationUser guest)
        {
            var hotelRole = (await this.hotelRoleRepo.GetAllAsync())
                .FirstOrDefault(hr => hr.HotelId == this.hotelId && hr.Role.Name == "Guest");

            var userHotelRole = new UserHotelRole()
            {
                UserId = guest.Id,
                HotelRoleId = hotelRole.Id,
            };

            await this.userHotelRoleRepo.AddAsync(userHotelRole);
            await this.userHotelRoleRepo.SaveChangesAsync();
        }

        private async Task<bool> IsTheGuestRegisteredBeforeAsync()
            => (await this.userRepo.GetAllAsync()).Any(u => u.Email == this.addReservationViewModel.Email);

        private async Task<ApplicationUser> CreateNewUserProfileAsync()
        {
            var guest = new ApplicationUser()
            {
                FirstName = this.addReservationViewModel.FirstName,
                LastName = this.addReservationViewModel.LastName,
                Email = this.addReservationViewModel.Email,
                UserName = this.addReservationViewModel.Email,
                ImageUrl = "http://res.cloudinary.com/hotelcollab/image/upload/v1616789646/blank-profile-picture-973460_ljoyoq.png",
            };

            await this.userManager.CreateAsync(guest, "Guest_123");

            await this.userManager.AddToRoleAsync(guest, "Guest");

            return guest;
        }

        private async Task<ApplicationUser> GetUserProfileAsync()
            => (await this.userRepo.GetAllAsync()).FirstOrDefault(u => u.Email == this.addReservationViewModel.Email);

        private void DeleteSignalsOfReservation(Reservation reservation)
        {
            if (reservation.Feedbacks.Any())
            {
                foreach (var signal in reservation.Feedbacks)
                {
                    this.feedbackRepo.Delete(signal);
                }
            }
        }

        private async Task<Reservation> GetReservationAsync()
            => await this.reservationRepo.GetAsync(this.reservationId);

        private async Task DeleteReservationAsync(Reservation reservation)
        {
            this.reservationRepo.Delete(reservation);

            await this.reservationRepo.SaveChangesAsync();
        }
    }
}
