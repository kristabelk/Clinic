using AppointmentSystem.Entities;
using AppointmentSystem.Repositories;

namespace AppointmentSystem.Services
{
    public class AppointmentService : IAppointmentService
    {
        public readonly IAppointmentRepository _appointmentRepository;
        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task CreateAppointment(Appointment appointment)
        {
            await _appointmentRepository.Add(appointment);
        }
    }
}
