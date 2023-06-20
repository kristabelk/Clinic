using AppointmentSystem.Database;
using AppointmentSystem.Entities;

namespace AppointmentSystem.Repositories
{
    public class AppointmentRepo : IAppointmentRepository
    {
        private ClinicDatabase _db;
        public AppointmentRepo(ClinicDatabase db)
        {
            _db = db;
        }

        public async Task Add(Appointment appointment)
        {
            _db.Appointments.Add(appointment);
            await _db.SaveChangesAsync();
        }

        public bool AppointmentGUIDIsExist(Guid appointmentGUID)
        {
            throw new NotImplementedException();
        }
    }
}
