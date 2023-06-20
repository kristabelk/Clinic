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
        public readonly ISlotRepository _slotRepository;  //can i do this???? is this bad? 

        public AppointmentService(IAppointmentRepository appointmentRepository, ISlotRepository slotRepository)
        {
            _appointmentRepository = appointmentRepository;
            _slotRepository = slotRepository;
        }

        public async Task CreateAppointment(Appointment appointment)
        {
            //check if appointment taken 
            var SlotID = appointment.SlotId;
            var slot = await _slotRepository.getBySlotID(SlotID.ToString());
            if (slot.IsReserved)
            {
                throw new SlotNotAvailableException();
            }
            else
            {
                appointment.ReserveAt = slot.Date;
                appointment.DoctorId = slot.DoctorId;
                await _appointmentRepository.Add(appointment);

                await _slotRepository.UpdateSlot(slot);

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
    }
}
