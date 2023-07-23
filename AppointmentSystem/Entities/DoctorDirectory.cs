using System.ComponentModel.DataAnnotations;

namespace AppointmentSystem.Entities
{
    public class DoctorDirectory
    {
        [Key]
        public Guid DoctorId { get; set; }
        public string DoctorName { get; set; }
    }
}
