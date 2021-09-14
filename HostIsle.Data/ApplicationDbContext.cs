namespace HostIsle.Data
{
    using System.Linq;
    using HostIsle.Data.Models.Common;
    using HostIsle.Data.Models.Hotels;
    using HostIsle.Data.Models.Restaurants;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// DbContext of the application.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options"> EF Database context options. </param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Common models

        /// <summary>
        /// Gets or sets table Addresses.
        /// </summary>
        public DbSet<Address> Addresses { get; set; }

        /// <summary>
        /// Gets or sets table Events.
        /// </summary>
        public DbSet<Event> Events { get; set; }

        /// <summary>
        /// Gets or sets table Locations.
        /// </summary>
        public DbSet<Location> Locations { get; set; }

        /// <summary>
        /// Gets or sets table Permissions.
        /// </summary>
        public DbSet<Permission> Permissions { get; set; }

        /// <summary>
        /// Gets or sets table PropertyTypes.
        /// </summary>
        public DbSet<PropertyType> PropertyTypes { get; set; }

        /// <summary>
        /// Gets or sets table Reviews.
        /// </summary>
        public DbSet<Review> Reviews { get; set; }

        /// <summary>
        /// Gets or sets table Signals.
        /// </summary>
        public DbSet<Signal> Signals { get; set; }

        /// <summary>
        /// Gets or sets table Towns.
        /// </summary>
        public DbSet<Town> Towns { get; set; }

        // Hotel models

        /// <summary>
        /// Gets or sets table Cleanings.
        /// </summary>
        public DbSet<Cleaning> Cleanings { get; set; }

        /// <summary>
        /// Gets or sets table Damages.
        /// </summary>
        public DbSet<Damage> Damages { get; set; }

        /// <summary>
        /// Gets or sets table Hotels.
        /// </summary>
        public DbSet<Hotel> Hotels { get; set; }

        /// <summary>
        /// Gets or sets table HotelReservations.
        /// </summary>
        public DbSet<HotelReservation> HotelReservations { get; set; }

        /// <summary>
        /// Gets or sets table Rooms.
        /// </summary>
        public DbSet<Room> Rooms { get; set; }

        // Restaurant models

        /// <summary>
        /// Gets or sets table Ingredients.
        /// </summary>
        public DbSet<Ingredient> Ingredients { get; set; }

        /// <summary>
        /// Gets or sets table Orders.
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Gets or sets table Products.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets table ProductIngredients.
        /// </summary>
        public DbSet<ProductIngredient> ProductIngredients { get; set; }

        /// <summary>
        /// Gets or sets table Restaurants.
        /// </summary>
        public DbSet<Restaurant> Restaurants { get; set; }

        /// <summary>
        /// Gets or sets table RestaurantReservations.
        /// </summary>
        public DbSet<RestaurantReservation> RestaurantReservations { get; set; }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
            optionsBuilder
                .UseLazyLoadingProxies();
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            builder.Entity<Address>()
                .HasOne(a => a.Town)
                .WithMany(t => t.Addresses)
                .HasForeignKey(a => a.TownId);

            builder.Entity<Event>()
                .HasOne(e => e.Property)
                .WithMany(p => p.Events)
                .HasForeignKey(e => e.PropertyId);

            builder.Entity<Location>()
                .HasOne(l => l.Address)
                .WithMany(a => a.Locations)
                .HasForeignKey(l => l.AddressId);

            builder.Entity<Location>()
                .HasOne(l => l.Owner)
                .WithMany(o => o.Locations)
                .HasForeignKey(l => l.OwnerId);

            builder.Entity<Damage>()
                .HasOne(d => d.Cleaning)
                .WithMany(c => c.Damages)
                .HasForeignKey(d => d.CleaningId);

            builder.Entity<Signal>()
                .HasOne(s => s.Reservation)
                .WithMany(r => r.Signals)
                .HasForeignKey(s => s.ReservationId);

            builder.Entity<Signal>()
                .HasOne(s => s.ProcessedByEmployee)
                .WithMany(p => p.Signals)
                .HasForeignKey(s => s.ProcessedByEmployeeId);

            builder.Entity<Cleaning>()
                .HasOne(c => c.Room)
                .WithMany(r => r.Cleanings)
                .HasForeignKey(c => c.RoomId);

            builder.Entity<Review>()
                .HasOne(r => r.Property)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.PropertyId);

            builder.Entity<Review>()
                .HasOne(r => r.Client)
                .WithMany(c => c.Reviews)
                .HasForeignKey(r => r.ClientId);

            builder.Entity<Room>()
                .HasOne(r => r.Hotel)
                .WithMany(h => h.Rooms)
                .HasForeignKey(r => r.HotelId);

            builder.Entity<Product>()
                .HasOne(p => p.Restaurant)
                .WithMany(r => r.Products)
                .HasForeignKey(p => p.RestaurantId);

            builder.Entity<ProductIngredient>()
                .HasKey(pi => new { pi.ProductId, pi.IngredientId });

            builder.Entity<ProductIngredient>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductIngredients)
                .HasForeignKey(pi => pi.ProductId);

            builder.Entity<ProductIngredient>()
                .HasOne(pi => pi.Ingredient)
                .WithMany(i => i.ProductIngredients)
                .HasForeignKey(pi => pi.IngredientId);

            builder.Entity<Order>()
                .HasOne(o => o.Restaurant)
                .WithMany(r => r.Orders)
                .HasForeignKey(o => o.RestaurantId);

            builder.Entity<Property>()
                .HasOne(p => p.Location)
                .WithMany(l => l.Properties)
                .HasForeignKey(p => p.LocationId);

            builder.Entity<Property>()
                .HasOne(p => p.Type)
                .WithMany(t => t.Properties)
                .HasForeignKey(p => p.TypeId);

            builder.Entity<Reservation>()
                .HasOne(r => r.ServicedBy)
                .WithMany(s => s.ProceededReservations)
                .HasForeignKey(r => r.ServicedById);

            builder.Entity<Reservation>()
                .HasOne(r => r.Guest)
                .WithMany(g => g.Reservations)
                .HasForeignKey(r => r.GuestId);

            builder.Entity<Reservation>()
                .HasOne(r => r.Property)
                .WithMany(p => p.Reservations)
                .HasForeignKey(r => r.PropertyId);

            builder.Entity<HotelReservation>()
                .HasOne(hr => hr.Room)
                .WithMany(r => r.Reservations)
                .HasForeignKey(hr => hr.RoomId);

            builder.Entity<Permission>()
                .HasKey(p => new { p.Id, p.PropertyId, p.RoleId });

            builder.Entity<Permission>()
                .HasOne(hr => hr.Property)
                .WithMany(p => p.Permissions)
                .HasForeignKey(hr => hr.PropertyId);

            builder.Entity<Permission>()
                .HasOne(hr => hr.Role)
                .WithMany(r => r.Permissions)
                .HasForeignKey(hr => hr.RoleId);
        }
    }
}
