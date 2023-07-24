using AppointmentSystem.Entities;

namespace AppointmentSystem.Repositories
{
    public interface IUserRepository
    {
        public Task AddNewPatient(PatientDirectory patientInfo);
        public Task AddNewDoctor(DoctorDirectory docInfo);
        public Task<PatientDirectory> CheckPatientExist(string? patientName);
        public Task<DoctorDirectory> CheckDocExist(string? DocName);
        public Task<List<DoctorDirectory>> GetAllDoc();
        public Task<List<PatientDirectory>> GetAllPatient();
    }
}
