using AppointmentSystem.Entities;
using AppointmentSystem.Repositories;

namespace AppointmentSystem.Services
{
    public class UserManagementService:IUserManagementService
    {
        public readonly IUserRepository _userRepository;
        private readonly ILogger<IUserManagementService> _logger;

        public UserManagementService(IUserRepository userRepository, ILogger<IUserManagementService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        /*   public async Task<bool> AddNewDoctor(DoctorDirectory docInfo)
         {
             if (await _userRepository.CheckDocExist(docInfo.DoctorName) == false)
             {
                 if (docInfo.DoctorId == Guid.Empty)
                 {
                     docInfo.DoctorId = Guid.NewGuid();
                 }
                 await _userRepository.AddNewDoctor(docInfo);
                 return true;
             }
             else
             {
                 _logger.LogInformation("doc exist, no action taken");
                 return false;
             }
         }

       public async Task<bool> AddNewPatient(PatientDirectory patientInfo)
         {
             if (await _userRepository.CheckPatientExist(patientInfo.PatientName) == false)
             {
                 if (patientInfo.PatientId == Guid.Empty)
                 {
                     patientInfo.PatientId = Guid.NewGuid();
                 }
                 await _userRepository.AddNewPatient(patientInfo);
                 return true;
             }
             else
             {
                 _logger.LogInformation("patient exist, no action taken");
                 return false;
             }

         }
        */
        public Task<DoctorDirectory> CheckDocExist(string? DocID)
        {
            return _userRepository.CheckDocExist(DocID);
            
        }

        public Task<PatientDirectory> CheckPatientExist(string? patientId)
        {
            return _userRepository.CheckPatientExist(patientId);
        }

        public Task<List<DoctorDirectory>> GetAllDoc()
        {
            return _userRepository.GetAllDoc();
            
        }

        public Task<List<PatientDirectory>> GetAllPatient()
        {
           return _userRepository.GetAllPatient();
        }
    }

    
}
