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

        public AuthenticationController(JwtCreator jwtCreator)
        {
            _jwtCreator = jwtCreator;
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
    }


}
