using AppointmentSystem.Entities;
using AppointmentSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSystem.Controllers
{
    [Route("/UserManagement")]
    [Authorize]
    public class UserManagementController:ControllerBase
    {
        private readonly IUserManagementService _userManagementService;
        private readonly ILogger<UserManagementController> _logger;

        public UserManagementController(IUserManagementService userManagementService, ILogger<UserManagementController> logger)
        {
            _userManagementService = userManagementService;
            _logger = logger;
        }
        [Route("/UserManagement/GetPatients")]
        [HttpGet]
        public async Task<IActionResult> GetPatients([FromHeader] string?PatientName)
        {   
            var patientlist = await _userManagementService.GetAllPatient();
            if(patientlist.Count!=0)
            {
                return Ok(patientlist);
            }
            return BadRequest("No Patient in record");

        }
        [Route("/UserManagement/GetDoctors")]
        [HttpGet]
        public async Task<IActionResult> GetDoc([FromHeader] string? DocName)
        {
            var doclist = await _userManagementService.GetAllDoc();
            if (doclist.Count != 0)
            {
                _logger.LogInformation("retrieving doctor list " + doclist);
                return Ok(doclist);
            }
            _logger.LogInformation("Doctor not found");
            return BadRequest("No doc in record");

        }
      /*  [Route("/UserManagement/AddDoctor")]
        [HttpPost]
        public async Task<IActionResult> AddDocToDB([FromBody] DoctorDirectory docInfo)
        {
            if (docInfo != null)
            {
                bool addsuccess = await _userManagementService.AddNewDoctor(docInfo);
                _logger.LogInformation("{1} added to doc list " ,docInfo.DoctorName);
                return Ok("Doc Added " +addsuccess);
            }
            _logger.LogError("Doc name missing");
            return BadRequest("input doc info");
        }

        [Route("/UserManagement/AddPatient")]
        [HttpPost]
        public async Task<IActionResult> AddPatientToDB([FromBody] PatientDirectory PatientInfo)
        {
            if (PatientInfo != null)
            {
                bool addsuccess = await _userManagementService.AddNewPatient(PatientInfo);
                _logger.LogInformation("{1} added to Patient list ", PatientInfo.PatientName);
                return Ok("Patient Added " + addsuccess);
            }
            _logger.LogError("Patient name missing");
            return BadRequest("input patient info");
        }*/
    }
}
