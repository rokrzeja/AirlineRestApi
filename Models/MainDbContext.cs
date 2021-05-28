using Microsoft.EntityFrameworkCore;
using project.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext() { }
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Arrival> Arrivals { get; set; }
        public DbSet<Departure> Departures { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<FlightInstance> FlightInstances { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Employee> Empolyees { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Steward> Stewards { get; set; }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Language> Languages { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Connection String ;)");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AirplaneEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ArrivalEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DepartureEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FlightEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FlightInstanceEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ClientEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FlightInstanceEmployeeAssociationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StewardEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StewardLanguageAssociationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PilotEntityTypeConfiguration());
        }





    }
}
