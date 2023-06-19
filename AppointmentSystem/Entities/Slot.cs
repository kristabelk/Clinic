using System;
using System.ComponentModel.DataAnnotations;

namespace AppointmentSystem.Entities
{
    public class Slot
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; } //or string? not sure.. tbc
        public Guid DoctorId { get; set; }
        public string DoctorName { get; set; }
        public bool IsReserved { get; set; }
        public decimal Cost { get; set; }

    }
}
