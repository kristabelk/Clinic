using System.ComponentModel.DataAnnotations;

namespace AppointmentSystem.Entities
{
    public class Appointment
    {
        public Guid Id { get; set; }
        [Required]
        public Guid SlotId { get; set; }
        public Guid PatientId { get; set; }
        [Required]
        public string PatientName { get; set;}
        public DateTime ReserveAt { get; set; }
    }
}
