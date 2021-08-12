namespace HostIsle.Data
{
    using System.Linq;
    using HostIsle.Data.Models.Hotels;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Request> Requests { get; set; }

        public DbSet<Damage> Damages { get; set; }

        public DbSet<Cleaning> Cleanings { get; set; }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<ApplicationUser> Users { get; set; }

        public DbSet<HotelRole> HotelRoles { get; set; }

        public DbSet<UserHotelRole> UserHotelRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
            optionsBuilder
                .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            builder.Entity<Request>()
                .HasOne(r => r.User)
                .WithMany(u => u.Requests)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Requests)
                .WithOne(r => r.User)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<Hotel>()
                .HasOne(h => h.Town)
                .WithMany(t => t.Hotels)
                .HasForeignKey(h => h.TownId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<Town>()
                .HasMany(x => x.Hotels)
                .WithOne(x => x.Town);

            builder.Entity<Room>()
                .HasOne(r => r.Hotel)
                .WithMany(h => h.Rooms)
                .HasForeignKey(r => r.HotelId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<Reservation>()
                .HasOne(r => r.Hotel)
                .WithMany(h => h.Reservations)
                .HasForeignKey(r => r.HotelId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<Reservation>()
                .HasOne(res => res.Room)
                .WithMany(rm => rm.Reservations)
                .HasForeignKey(res => res.RoomId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<Reservation>()
                .HasOne(r => r.Receptionist)
                .WithMany(r => r.Reservations)
                .HasForeignKey(r => r.ReceptionistId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<Event>()
                .HasOne(e => e.Hotel)
                .WithMany(h => h.Events)
                .HasForeignKey(e => e.HotelId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<Feedback>()
                .HasOne(f => f.Guest)
                .WithMany(u => u.Feedbacks)
                .HasForeignKey(f => f.GuestId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<Feedback>()
                .HasOne(f => f.ProcessedByEmployee)
                .WithMany(u => u.ProcessedFeedbacks)
                .HasForeignKey(f => f.ProcessedByEmployeeId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<Feedback>()
                .HasOne(f => f.Reservation)
                .WithMany(r => r.Feedbacks)
                .HasForeignKey(f => f.ReservationId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<Feedback>()
                .HasOne(f => f.Hotel)
                .WithMany(h => h.Feedbacks)
                .HasForeignKey(f => f.HotelId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<Cleaning>()
                .HasOne(c => c.Cleaner)
                .WithMany(c => c.Cleanings)
                .HasForeignKey(c => c.CleanerId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<Cleaning>()
                .HasOne(c => c.Room)
                .WithMany(r => r.Cleanings)
                .HasForeignKey(c => c.RoomId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<Damage>()
                .HasOne(d => d.Cleaning)
                .WithMany(c => c.Damages)
                .HasForeignKey(d => d.CleaningId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<HotelRole>()
                .HasOne(hr => hr.Hotel)
                .WithMany(h => h.HotelRoles)
                .HasForeignKey(uh => uh.HotelId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<HotelRole>()
                .HasOne(uh => uh.Role)
                .WithMany(h => h.HotelRoles)
                .HasForeignKey(uh => uh.RoleId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<UserHotelRole>()
                .HasKey(uhr => new { uhr.Id, uhr.UserId, uhr.HotelRoleId });

            builder.Entity<UserHotelRole>()
                .HasOne(uhr => uhr.User)
                .WithMany(u => u.UserHotelRoles)
                .HasForeignKey(uhr => uhr.UserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<UserHotelRole>()
                .HasOne(uhr => uhr.HotelRole)
                .WithMany(hr => hr.UserHotelRoles)
                .HasForeignKey(uhr => uhr.HotelRoleId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<ApplicationUserRole>()
                .HasOne(ur => ur.Hotel)
                .WithMany(h => h.UserRoles)
                .HasForeignKey(ur => ur.HotelId);

            builder.Entity<Request>()
                .HasOne(r => r.Hotel)
                .WithMany(h => h.Requests)
                .HasForeignKey(r => r.HotelId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
