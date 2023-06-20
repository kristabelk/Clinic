using Microsoft.EntityFrameworkCore;
using AppointmentSystem.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentSystem.Database
{
    public class SlotConfiguration :IEntityTypeConfiguration <Slot>
    {
        public void Configure(EntityTypeBuilder<Slot> builder)
        {
            builder.ToTable("Slots");
            builder.HasKey(x => x.Id);
        }
    }
}
