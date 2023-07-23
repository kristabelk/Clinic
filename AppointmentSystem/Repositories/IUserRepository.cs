using AppointmentSystem.Entities;

namespace AppointmentSystem.Repositories
{
    public interface IUserRepository
    {
        public Task AddNewPatient(PatientDirectory patientInfo);
        public Task AddNewDoctor(DoctorDirectory docInfo);
        public Task<bool> CheckPatientExist(string? patientId);
        public Task<bool> CheckDocExist(string? DocID);
        public Task<List<DoctorDirectory>> GetAllDoc();
        public Task<List<PatientDirectory>> GetAllPatient();
    }
}
