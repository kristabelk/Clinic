using AppointmentSystem.Controllers;
using AppointmentSystem.Entities;
using AppointmentSystem.Repositories;
using AppointmentSystem.Services.Exceptions;

namespace AppointmentSystem.Services
{
    public class AppointmentService : IAppointmentService
    {
        public readonly SlotController slotController;
        public readonly IAppointmentRepository _appointmentRepository;
        public readonly ISlotRepository _slotRepository; 

        private readonly ILogger<IAppointmentService> _logger;

        public AppointmentService(IAppointmentRepository appointmentRepository, ISlotRepository slotRepository, ILogger<IAppointmentService> logger)
        {
            _appointmentRepository = appointmentRepository;
            _slotRepository = slotRepository;
            _logger = logger;
        }

        public async Task CreateAppointment(Appointment appointment)
        {
            //check if appointment taken 
            var SlotID = appointment.SlotId;
            var slot = await _slotRepository.getBySlotID(SlotID.ToString());
            if (slot.IsReserved)
            {
                _logger.LogError("Slot taken, Appointment creation fail");
                throw new SlotNotAvailableException();
            }
            else
            {
                appointment.ReserveAt = slot.Date;
                appointment.DoctorId = slot.DoctorId;
                await _appointmentRepository.Add(appointment);

                await _slotRepository.UpdateSlot(slot);
                SendNotification(appointment,slot);
            }
        }

        public async Task<List<Appointment>> GetAll(string? name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return await _appointmentRepository.GetAll();
                //throw new CategoryNameEmptyException();
            }
            else
            {
                var appt = await _appointmentRepository.getByDocID(name);
                if (appt == null)
                    return new List<Appointment> { };
                return appt;
            }
        }

        public void SendNotification(Appointment appointment, Slot slot)
        {
            string patientName = appointment.PatientName;
            string docName = slot.DoctorName;
            string dateTime = appointment.ReserveAt.ToString("dd-MM-yyyy hh:mm tt");

             _logger.LogInformation("Patient Notification: Dear {1}, your appointment with {2} is confirmed. Please be at the clinic on {3}", patientName, docName, dateTime);
            _logger.LogInformation("Doctor Notification: Dear {1}, you have an appointment on {2} with {3}", docName, dateTime, patientName);
        }
    }
}
