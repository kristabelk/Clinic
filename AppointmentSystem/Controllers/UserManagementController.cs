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
                return Ok(doclist);
            }
            return BadRequest("No doc in record");

        }
        [Route("/UserManagement/AddDoctor")]
        [HttpPost]
        public async Task<IActionResult> AddDocToDB([FromBody] DoctorDirectory docInfo)
        {
            if (docInfo != null)
            {
                bool addsuccess = await _userManagementService.AddNewDoctor(docInfo);
                return Ok("Doc Added " +addsuccess);
            }
            return BadRequest("input doc info");
        }

        [Route("/UserManagement/AddPatient")]
        [HttpPost]
        public async Task<IActionResult> AddPatientToDB([FromBody] PatientDirectory PatientInfo)
        {
            if (PatientInfo != null)
            {
                bool addsuccess = await _userManagementService.AddNewPatient(PatientInfo);
                return Ok("Patient Added " + addsuccess);
            }
            return BadRequest("input patient info");
        }
    }
}
