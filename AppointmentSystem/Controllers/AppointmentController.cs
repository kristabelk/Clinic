using AppointmentSystem.Controllers.Dtos;
using AppointmentSystem.Entities;
using AppointmentSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSystem.Controllers
{
    [Route("/appointments")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost]
        public async Task <IActionResult> Post([FromBody] CreateAppointmentRequest appointment)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(value => value.Errors)
                    .Select(error => error.ErrorMessage)
                    .ToList();
                return BadRequest(errors);
            }

            await _appointmentService.CreateAppointment(appointment.ConvertToAppointment());
            return Ok("Appointment Created..");
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromHeader] string? DocID)
        {
            var apptResult = await _appointmentService.GetAll(DocID);
            if (apptResult.Count == 0)
                return BadRequest("no appt found");
            
            return Ok(apptResult);
        }


    }
}
