using AppointmentSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystem.Database
{
    public class ClinicDatabase : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Slot> Slots { get; set; }
        public DbSet<DoctorDirectory> DoctorDirectories { get; set; }
        public DbSet<PatientDirectory> PatientDirectories { get; set; }

        public ClinicDatabase(DbContextOptions<ClinicDatabase> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Clinic_Db");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }

    public static class DbExtension
    {
        public static IServiceCollection AddClinicDb(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<ClinicDatabase>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Postgres"));
            });
            return service;
        }
    }
}
