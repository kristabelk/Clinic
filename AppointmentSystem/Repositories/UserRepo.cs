using AppointmentSystem.Database;
using AppointmentSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystem.Repositories
{
    public class UserRepo :IUserRepository
    {
        private ClinicDatabase _db;
        public UserRepo(ClinicDatabase db)
        {
            _db = db;
        }

        public async Task AddNewPatient(PatientDirectory patientInfo)
        {
            _db.PatientDirectories.Add(patientInfo);
            await _db.SaveChangesAsync();
        }

        public async Task AddNewDoctor(DoctorDirectory docInfo)
        {
            _db.DoctorDirectories.Add(docInfo);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> CheckPatientExist(string? patientName)
        {
            var doc = await _db.PatientDirectories.Where(x => x.PatientName == patientName).ToListAsync();
            if (doc.Count == 0)
                return false;
            return true;
        }

        public async Task<bool> CheckDocExist(string? DocName)
        {

            var doc = await _db.DoctorDirectories.Where(x => x.DoctorName == DocName).ToListAsync();
            if (doc.Count == 0)
                return false;
            return true;
        }

        public async Task<List<DoctorDirectory>> GetAllDoc()
        {
            return _db.DoctorDirectories.ToList();
        }

        public async Task<List<PatientDirectory>> GetAllPatient()
        {
            return _db.PatientDirectories.ToList();
        }
    }
    
}
