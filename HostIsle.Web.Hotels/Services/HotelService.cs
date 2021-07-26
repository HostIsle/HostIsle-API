namespace HostIsle.Web.Hotels.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using HostIsle.Data;
    using HostIsle.Data.Models.Hotels;
    using HostIsle.Web.Hotels.Services.Interfaces;
    using HostIsle.Web.Hotels.ViewModels.Hotels;
    using Microsoft.AspNetCore.Http;

    public class HotelService : IHotelService
    {
        private readonly IRepository<Room> roomRepo;
        private readonly IRepository<Cleaning> cleaningRepo;
        private readonly IRepository<ApplicationUser> userRepo;
        private readonly IRepository<Reservation> reservationRepo;
        private readonly IRepository<UserHotelRole> userHotelRoleRepo;
        private readonly IRepository<Hotel> hotelRepo;
        private readonly IRepository<Town> townRepo;
        private readonly IRepository<ApplicationRole> roleRepo;
        private readonly IHttpContextAccessor httpContextAccessor;

        public HotelService(IRepository<Room> roomRepo, IRepository<Cleaning> cleaningRepo, IRepository<ApplicationUser> userRepo, IRepository<Reservation> reservationRepo, IRepository<UserHotelRole> userHotelRoleRepo, IRepository<Hotel> hotelRepo, IRepository<Town> townRepo, IRepository<ApplicationRole> roleRepo, IHttpContextAccessor httpContextAccessor)
        {
            this.roomRepo = roomRepo;
            this.cleaningRepo = cleaningRepo;
            this.userRepo = userRepo;
            this.reservationRepo = reservationRepo;
            this.userHotelRoleRepo = userHotelRoleRepo;
            this.hotelRepo = hotelRepo;
            this.townRepo = townRepo;
            this.roleRepo = roleRepo;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateAsync(HotelRegisterViewModel model)
        {
            var imageUrl = string.Empty;

            if (model.Image != null && model.Image.Length > 0)
            {
                var fileName = Path.GetFileName(model.Image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", fileName);

                using var fileStream = new FileStream(filePath, FileMode.Create);

                await model.Image.CopyToAsync(fileStream);

                var account = new Account { ApiKey = "597981955165718", ApiSecret = "YrIRgn7E7ffUnN1kXSJhyGQJS54", Cloud = "hotelcollab" };

                fileStream.Close();

                var cloudinary = new Cloudinary(account);

                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(filePath),
                };

                var result = cloudinary.Upload(uploadParams);

                File.Delete(filePath);

                imageUrl = result.Url.ToString();
            }

            var towns = await this.townRepo.GetAllAsync();

            towns = towns
                .Where(town => town.Name == model.TownName).ToList();

            Town town;

            if (!towns.Any())
            {
                town = new Town
                {
                    Name = model.TownName,
                };

                await this.townRepo.AddAsync(town);
            }
            else
            {
                town = towns.FirstOrDefault();
            }

            var hotel = new Hotel(imageUrl)
            {
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                CleaningPeriod = model.CleaningPeriod,
                TownId = town.Id,
            };

            town.Hotels.Add(hotel);

            foreach (var role in await this.roleRepo.GetAllAsync())
            {
                hotel.HotelRoles.Add(new HotelRole
                {
                    HotelId = hotel.Id,
                    RoleId = (await this.roleRepo.GetAllAsync()).FirstOrDefault(r => r.Name == role.Name)?.Id,
                });
            }

            await this.townRepo.SaveChangesAsync();
            await this.hotelRepo.SaveChangesAsync();

            await this.userHotelRoleRepo.AddAsync(new UserHotelRole
            {
                UserId = this.httpContextAccessor.HttpContext.User.FindFirst("Id").Value,
                HotelRoleId = hotel.HotelRoles.FirstOrDefault(hr => hr.Role.Name == "Manager").Id,
            });

            await this.userHotelRoleRepo.SaveChangesAsync();
        }

        public async Task<List<Hotel>> GetAllAsync() => await this.hotelRepo.GetAllAsync();

        public async Task<HotelInformationViewModel> LoadCurrentHotelAsync(string id)
        {
            var hotelInfo = id?.Split();
            var hotelId = hotelInfo != null ? hotelInfo[0] : null;
            string role = string.Empty;
            string employeeRole = string.Empty;
            Reservation reservation = null;
            ApplicationUser user = null;
            ApplicationUser currentUser= null;

            if (hotelInfo?.Length >= 2)
            {
                role = hotelInfo[1];
            }

            if (hotelInfo?.Length >= 3)
            {
                var currentId = hotelInfo[2];
                reservation = await this.reservationRepo.GetAsync(currentId);
                user = await this.userRepo.GetAsync(currentId);
            }

            if (hotelInfo?.Length == 4)
            {
                employeeRole = hotelInfo[3];
            }

            if (role == "Guest")
            {
                user = (await this.userRepo.GetAllAsync()).FirstOrDefault(u => u.Id == this.httpContextAccessor.HttpContext.User.FindFirst("Id").Value);
                reservation = (await this.reservationRepo.GetAllAsync()).FirstOrDefault(r =>
                r.Guest.Id == user.Id &&
                r.EndDate.AddDays(1) > DateTime.Now);
            }

            var userId = this.httpContextAccessor.HttpContext.User.FindFirst("Id").Value;

            currentUser = await this.userRepo.GetAsync(userId);

            var hotel = await this.hotelRepo.GetAsync(hotelId);

            var floors = (await this.roomRepo.GetAllAsync()).Where(r => r.HotelId == hotelId).Select(r => r.Floor).ToHashSet();

            var cleanings = (await this.cleaningRepo.GetAllAsync()).Where(c => c.Room.HotelId == hotelId).ToList();

            var cleaners = (await this.userHotelRoleRepo.GetAllAsync()).Where(uh => uh.HotelRole.HotelId == hotelId && uh.HotelRole.Role.Name == "Cleaner").ToList();

            var receptionists = (await this.userHotelRoleRepo.GetAllAsync()).Where(uh => uh.HotelRole.HotelId == hotelId && uh.HotelRole.Role.Name == "Receptionist").ToList();

            var isManager = (await this.userHotelRoleRepo.GetAllAsync())
                .Where(uhr => uhr.User.Id == userId && uhr.HotelRole.HotelId == hotelId)
                .Any(uhr => uhr.User.UserHotelRoles.Any(u => u.HotelRole.Role.Name == "Manager"));

            var model = new HotelInformationViewModel()
            {
                Hotel = hotel,
                Cleaners = cleaners,
                Receptionists = receptionists,
                IsManager = isManager,
                Role = role,
                EmployeeRole = employeeRole,
                Reservation = reservation,
                User = user,
                Cleanings = cleanings,
                Floors = floors,
                UserId = userId,
                CurrentUser = currentUser,
            };

            return model;
        }
    }
}
