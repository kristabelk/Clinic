using AppointmentSystem.Entities;
using System.ComponentModel.DataAnnotations;

namespace AppointmentSystem.Controllers.Dtos
{
    public class CreateAppointmentRequest
    {
        public string SlotId { get; set; }
        public string PatientName { get; set; }
        

        public Appointment ConvertToAppointment()
        {
            //DateTime
            return new Appointment
            {
                Id = Guid.NewGuid(),
                SlotId = Guid.Parse(SlotId),
                PatientName = PatientName,
                //PatientId = Guid.NewGuid()
            //    ReservedAt = 

    };
        }
    }
}
