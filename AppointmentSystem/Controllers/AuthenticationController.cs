using AppointmentSystem.Controllers.Dtos;
using Microsoft.AspNetCore.Mvc;
using AppointmentSystem.Security;
using AppointmentSystem.Services;
using Microsoft.AspNetCore.Authorization;



namespace AppointmentSystem.Controllers
{
    [Route("/login")]
    public class AuthenticationController:ControllerBase
    {
        private readonly JwtCreator _jwtCreator;
        private readonly IUserManagementService _userManagementService;
        private readonly ILogger<AuthenticationController> _logger; 

        public AuthenticationController(JwtCreator jwtCreator, IUserManagementService userManagementService, ILogger<AuthenticationController> logger)
        {
            _jwtCreator = jwtCreator;
            _userManagementService = userManagementService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginRequest request)
        {
            if (request != null)
            {
                
                if (request.Username == "admin")
                {
                    _logger.LogInformation("Logging in as admin");
                    return Ok(_jwtCreator.GenerateJsonWebToken("admin"));

                }
                
            }
            _logger.LogInformation("Unauthorized login");
            return Unauthorized();
            
        }
        [Route("/login/Doctor")]
        [HttpPost]
        public async Task<IActionResult> DocLogin([FromBody] LoginRequest request)
        {
            if (request != null)
            {

                await _userManagementService.CheckDocExist(request.Username);
          
                    _logger.LogInformation("Doctor login success");
                    return Ok(_jwtCreator.GenerateJsonWebToken(request.Username));
               

            }
            _logger.LogInformation("Unauthorized login");
            return Unauthorized();
        }

        [Route("/login/Patient")]
        [HttpPost]
        public async Task<IActionResult> PatientLogin([FromBody] LoginRequest request)
        {
            if (request != null)
            {

                await _userManagementService.CheckPatientExist(request.Username);
                {
                    _logger.LogInformation("Doctor login success");
                    return Ok(_jwtCreator.GenerateJsonWebToken(request.Username));
                }

            }
            _logger.LogInformation("Unauthorized login");
            return Unauthorized();
        }
    }


}
