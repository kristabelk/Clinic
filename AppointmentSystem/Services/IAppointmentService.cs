using AppointmentSystem.Entities;

namespace AppointmentSystem.Services
{
    public interface IAppointmentService
    {
        public Task CreateAppointment(Appointment appointment);
    }
}
