using HostIsle.Data.Models.Common;

namespace HostIsle.Web.Hotels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HostIsle.Data;
    using HostIsle.Data.Models.Hotels;
    using HostIsle.Services;
    using HostIsle.Services.Interfaces;
    using HostIsle.Web.Hotels.Areas.Manager.Services.Interfaces;
    using HostIsle.Web.Hotels.Areas.Mananger.Services;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.HttpsPolicy;
    using Microsoft.AspNetCore.Identity;
    //using Microsoft.AspNetCore.Identity.UI;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    this.Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDatabaseDeveloperPageExceptionFilter();

            //services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddRoles<ApplicationRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddTransient<IRepository<ApplicationRole>, Repository<ApplicationRole>>();
            services.AddTransient<IRepository<ApplicationUser>, Repository<ApplicationUser>>();
            services.AddTransient<IRepository<ApplicationUserRole>, Repository<ApplicationUserRole>>();
            services.AddTransient<IRepository<Cleaning>, Repository<Cleaning>>();
            services.AddTransient<IRepository<Damage>, Repository<Damage>>();
            services.AddTransient<IRepository<Event>, Repository<Event>>();
            services.AddTransient<IRepository<Signal>, Repository<Signal>>();
            services.AddTransient<IRepository<Hotel>, Repository<Hotel>>();
            services.AddTransient<IRepository<Reservation>, Repository<Reservation>>();
            services.AddTransient<IRepository<Room>, Repository<Room>>();
            services.AddTransient<IRepository<Town>, Repository<Town>>();

            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<Areas.Manager.Services.Interfaces.IRequestService, Areas.Mananger.Services.RequestService>();
            services.AddScoped<Services.Interfaces.IRequestService, Services.RequestService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<Services.Interfaces.ISignalService, Services.SignalService>();
            services.AddScoped<Areas.Guest.Services.Interfaces.ISignalService, Areas.Guest.Services.SignalService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<Areas.Guest.Services.Interfaces.ICleaningService, Areas.Guest.Services.CleaningService>();
            services.AddScoped<Services.Interfaces.ICleaningService, Services.CleaningService>();

            services.AddControllersWithViews();

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapRazorPages();
            });
        }
    }
}
