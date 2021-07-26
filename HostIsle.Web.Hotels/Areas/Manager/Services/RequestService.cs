namespace HostIsle.Web.Hotels.Areas.Mananger.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using HostIsle.Data;
    using HostIsle.Data.Models.Hotels;
    using HostIsle.Web.Hotels.Areas.Manager.Services.Interfaces;
    using Microsoft.AspNetCore.Identity;

    public class RequestService : IRequestService
    {
        private readonly IRepository<HotelRole> hotelRoleRepo;
        private readonly IRepository<UserHotelRole> userHotelRoleRepo;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRepository<Request> requestRepo;
        private readonly IRepository<ApplicationUser> userRepo;
        private readonly IRepository<ApplicationRole> roleRepo;

        public RequestService(IRepository<HotelRole> hotelRoleRepo, IRepository<UserHotelRole> userHotelRoleRepo, UserManager<ApplicationUser> userManager, IRepository<Request> requestRepo, IRepository<ApplicationUser> userRepo, IRepository<ApplicationRole> roleRepo)
        {
            this.hotelRoleRepo = hotelRoleRepo;
            this.userHotelRoleRepo = userHotelRoleRepo;
            this.userManager = userManager;
            this.requestRepo = requestRepo;
            this.userRepo = userRepo;
            this.roleRepo = roleRepo;
        }

        public async Task<string> AcceptAsync(string id)
        {
            var request = await this.requestRepo.GetAsync(id);

            var role = (await this.roleRepo.GetAllAsync()).FirstOrDefault(r => r.Name == request.Role);

            var user = await this.userRepo.GetAsync(request.UserId);

            var hotelRole = (await this.hotelRoleRepo.GetAllAsync()).FirstOrDefault(hr => hr.HotelId == request.HotelId && hr.Role.Name == request.Role);

            var userHotelRole = new UserHotelRole()
            {
                UserId = request.UserId,
                HotelRoleId = hotelRole.Id,
            };

            await this.userManager.AddToRoleAsync(user, role.Name);
            await this.userHotelRoleRepo.AddAsync(userHotelRole);
            await this.userHotelRoleRepo.SaveChangesAsync();

            this.requestRepo.Delete(request);
            await this.requestRepo.SaveChangesAsync();

            return request.HotelId + " Manager";
        }

        public async Task<string> DeleteAsync(string id)
        {
            var request = await this.requestRepo.GetAsync(id);

            this.requestRepo.Delete(request);

            await this.requestRepo.SaveChangesAsync();

            return request.HotelId + " Manager";
        }
    }
}
