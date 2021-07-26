namespace HostIsle.Web.Hotels.Areas.Mananger.Services
{
    using System;
    using System.Threading.Tasks;
    using HostIsle.Data;
    using HostIsle.Data.Models.Hotels;
    using HostIsle.Web.Hotels.Areas.Manager.Services.Interfaces;
    using HostIsle.Web.Hotels.ViewModels.Hotels;

    public class RoomService : IRoomService
    {
        private readonly IRepository<Room> roomRepo;

        public RoomService(IRepository<Room> roomRepo)
        {
            this.roomRepo = roomRepo;
        }

        public async Task CreateAsync(HotelInformationViewModel model, string id)
        {
            var hotelId = id.Split()[0];

            var room = new Room()
            {
                RoomNumber = model.RoomRegisterViewModel.RoomNumber,
                Floor = model.RoomRegisterViewModel.Floor,
                RoomType = model.RoomRegisterViewModel.Type,
                HotelId = hotelId,
            };

            await this.roomRepo.AddAsync(room);
            await this.roomRepo.SaveChangesAsync();
        }
    }
}
