namespace TravelAgent.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using TravelAgent.Data.Models;

    public class TravelAgentDbContext : IdentityDbContext
    {
        public DbSet<Tour> Tours { get; set; }

        public DbSet<Holiday> Holidays { get; set; }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<Day> Days { get; set; }

        public DbSet<AdditionalService> AdditionalServices { get; set; }

        public DbSet<Bus> Buses { get; set; }

        public DbSet<Seat> Seats { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Subscriber> Subscribers { get; set; }

        public TravelAgentDbContext(DbContextOptions<TravelAgentDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Reservation>()
                .HasOne(r => r.Trip)
                .WithMany(t=>t.Reservations)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            model.Entity<Trip>()
                .HasMany(t => t.Reservations)
                .WithOne(r => r.Trip)
                .HasForeignKey(r => r.TripId)
                .OnDelete(DeleteBehavior.Restrict);

            //model.Entity<ReservationAdditionalService>()
            //    .HasKey(ras => new { ras.ReservationId, ras.AdditionalServiceId });

            //model.Entity<ReservationAdditionalService>()
            //    .HasOne(ras => ras.AdditionalService)
            //    .WithMany(ad => ad.Reservations)
            //    .HasForeignKey(ras => ras.AdditionalServiceId);
            //model.Entity<ReservationAdditionalService>()
            //    .HasOne(ad => ad.Reservation)
            //    .WithMany(r => r.IncludedAdditionalServices)
            //    .HasForeignKey(ad => ad.ReservationId);

            base.OnModelCreating(model);
        }
    }
}
