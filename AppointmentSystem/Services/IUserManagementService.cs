using AppointmentSystem.Entities;

namespace AppointmentSystem.Services
{
    public interface IUserManagementService
    {
      //  public Task<bool> AddNewDoctor(DoctorDirectory docInfo);
      //  public Task<bool> AddNewPatient(PatientDirectory patientInfo);
        public Task<PatientDirectory> CheckPatientExist(string? patientName);
        public Task<DoctorDirectory> CheckDocExist(string? DocName);
        public Task<List<DoctorDirectory>> GetAllDoc();
        public Task<List<PatientDirectory>> GetAllPatient();
    }
}
