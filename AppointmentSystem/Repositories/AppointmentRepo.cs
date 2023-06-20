using AppointmentSystem.Database;
using AppointmentSystem.Entities;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<Appointment>> GetAll()
        {
            return _db.Appointments.ToList();
        }

        public async Task <List<Appointment>> getByDocID(string? DocID)
        {
            return await _db.Appointments.Where(x => x.DoctorId.ToString() == DocID).ToListAsync();
        }
    }
}
