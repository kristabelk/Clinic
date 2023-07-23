using System.ComponentModel.DataAnnotations;

namespace AppointmentSystem.Entities
{
    public class PatientDirectory
    {
        [Key]
        public Guid PatientId { get; set; }
        public string PatientName { get; set;}
       
    }
}
