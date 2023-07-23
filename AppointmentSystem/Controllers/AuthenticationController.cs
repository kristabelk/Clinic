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

        public AuthenticationController(JwtCreator jwtCreator, IUserManagementService userManagementService)
        {
            _jwtCreator = jwtCreator;
            _userManagementService = userManagementService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginRequest request)
        {
            if (request != null)
            {
                
                if (request.Username == "admin")
                {
                    return Ok(_jwtCreator.GenerateJsonWebToken("admin"));

                }
                
            }
            return Unauthorized();
        }
        [Route("/login/Doctor")]
        [HttpPost]
        public async Task<IActionResult> DocLogin([FromBody] LoginRequest request)
        {
            if (request != null)
            {
                
                if (await _userManagementService.CheckDocExist(request.Username) ==true)
                {
                    return Ok(_jwtCreator.GenerateJsonWebToken(request.Username));
                }

            }
            return Unauthorized();
        }

        [Route("/login/Patient")]
        [HttpPost]
        public async Task<IActionResult> PatientLogin([FromBody] LoginRequest request)
        {
            if (request != null)
            {

                if (await _userManagementService.CheckPatientExist(request.Username) == true)
                {
                    return Ok(_jwtCreator.GenerateJsonWebToken(request.Username));
                }

            }
            return Unauthorized();
        }
    }


}
