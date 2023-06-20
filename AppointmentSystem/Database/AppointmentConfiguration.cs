using Microsoft.EntityFrameworkCore;
using AppointmentSystem.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentSystem.Database
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointments");
            builder.HasKey(x => x.Id);
        }
    }
}
