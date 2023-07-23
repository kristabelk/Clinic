using AppointmentSystem.Entities;

namespace AppointmentSystem.Services
{
    public interface IUserManagementService
    {
        public Task<bool> AddNewDoctor(DoctorDirectory docInfo);
        public Task<bool> AddNewPatient(PatientDirectory patientInfo);
        public Task<bool> CheckPatientExist(string? patientId);
        public Task<bool> CheckDocExist(string? DocID);
        public Task<List<DoctorDirectory>> GetAllDoc();
        public Task<List<PatientDirectory>> GetAllPatient();
    }
}
