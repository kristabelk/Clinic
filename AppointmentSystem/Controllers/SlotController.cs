using AppointmentSystem.Services;
using Microsoft.AspNetCore.Mvc;
using AppointmentSystem.Entities;
using AppointmentSystem.Controllers.Dtos;

namespace AppointmentSystem.Controllers
{
    [Route("/slots")]
    public class SlotController : ControllerBase
    {
        private readonly ISlotService _slotService;

        public SlotController(ISlotService slotService)
        {
            _slotService = slotService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSlotRequest slot)
        {
           /* if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(value => value.Errors)
                    .Select(error => error.ErrorMessage)
                    .ToList();
                return BadRequest(errors);
            }*/
            await _slotService.CreateSlot(slot.ConvertToSlot());
            return Ok("slot Created..");
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromHeader] string? name)
        {
            var slotResult = await _slotService.GetAll(name);
            if (slotResult.Count == 0)
                return BadRequest("Doctor not found");
            return Ok(slotResult);
        }
    }

}
    

