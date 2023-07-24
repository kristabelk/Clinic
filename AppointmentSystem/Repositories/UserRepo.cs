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

        public async Task<PatientDirectory> CheckPatientExist(string? patientName)
        {
            var Patient = await _db.PatientDirectories.Where(x => x.PatientName == patientName).ToListAsync();
            if (Patient.Count == 0 && patientName!=null)
            {
                PatientDirectory newPatient = new PatientDirectory();
                newPatient.PatientName = patientName;
                newPatient.PatientId = Guid.NewGuid();
                await AddNewPatient(newPatient);
                return newPatient;
            }
            return Patient[0]; //return first for now.. 
        }

        public async Task<DoctorDirectory> CheckDocExist(string? DocName)
        {

            var doc = await _db.DoctorDirectories.Where(x => x.DoctorName == DocName).ToListAsync();
            if (doc.Count == 0 && DocName!=null)
            {
                DoctorDirectory newDoc = new DoctorDirectory();
                newDoc.DoctorName = DocName;
                newDoc.DoctorId = Guid.NewGuid();
                await AddNewDoctor(newDoc);
                return newDoc;
            }
            return doc[0];
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
