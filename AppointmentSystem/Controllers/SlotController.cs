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
        //public List<Slot> QueriedSlots { get; set; }

        public SlotController(ISlotService slotService)
        {
            _slotService = slotService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSlotRequest slot)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(value => value.Errors)
                    .Select(error => error.ErrorMessage)
                    .ToList();
                return BadRequest(errors);
            }
            await _slotService.CreateSlot(slot.ConvertToSlot());
            return Ok("Slot Created..");
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromHeader] string? DocID)
        {
            var slotResult = await _slotService.GetAll(DocID);
            if (slotResult.Count == 0)
                return BadRequest("Doctor not found");
           // QueriedSlots = slotResult.ToList();
            return Ok(slotResult);
        }

        [Route("/slots/Available")]
        [HttpGet]
        public async Task<IActionResult> GetAvailableSlots([FromHeader] string? DocID)
        {
            var slotResult = await _slotService.GetAvailable(DocID);
            if (slotResult.Count == 0)
                return BadRequest("Doctor not found");
            // QueriedSlots = slotResult.ToList();
            return Ok(slotResult);
        }


        public async Task <IActionResult> GetBySlotID(string slotID)
        {
            Slot SlotInfo = await _slotService.GetBySlotID(slotID);
            if (SlotInfo == null)
                return BadRequest("slot not found!");
            return Ok(SlotInfo);
        }
    }

}
    

