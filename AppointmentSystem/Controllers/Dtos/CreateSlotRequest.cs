using AppointmentSystem.Entities;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace AppointmentSystem.Controllers.Dtos
{
    public class CreateSlotRequest
    {
        [Required(ErrorMessage = "Input time and date in dd/MM/yyyy hh:mm tt format!")]
        public string Time { get; set; }
        [Range(1,10000)]
        public decimal Cost { get; set; }
        public Guid DoctorId { get; set; }
        [Required]
        public string DoctorName { get; set; }
        [Required]
        public bool IsReserved { get; set; }

        public Slot ConvertToSlot()
        {
            DateTime dateTime;
            if (!DateTime.TryParseExact(Time, "dd/MM/yyyy hh:mm tt", null, System.Globalization.DateTimeStyles.None, out dateTime))
            {
                // Handle invalid date format here
                throw new Exception("Invalid date format.");
            }
            return new Slot
            {
                Id = Guid.NewGuid(),
                Date = dateTime.ToUniversalTime(),
                DoctorId = DoctorId,
                DoctorName = DoctorName,
                IsReserved = IsReserved,
                Cost = Cost
            };
        }
    }

    
}

