using AppointmentSystem.Entities;

namespace AppointmentSystem.Repositories
{
    public interface IAppointmentRepository
    {
        public bool AppointmentGUIDIsExist (Guid appointmentGUID);
        public Task Add(Appointment appointment);
    }
}
