using AppointmentSystem.Entities;
using AppointmentSystem.Repositories;
using AppointmentSystem.Services.Exceptions;

namespace AppointmentSystem.Services
{
    public class SlotService : ISlotService
    {
        private readonly ISlotRepository _slotRepository;
        public SlotService(ISlotRepository slotRepository)
        {
            _slotRepository = slotRepository;
        }
        public async Task CreateSlot(Slot slot)
        {
            if (slot.DoctorName == null)
                throw new SlotException();
            await _slotRepository.Add(slot);

        }

        public async Task<List<Slot>> GetAll(string? name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return await _slotRepository.GetAll();
                //throw new CategoryNameEmptyException();
            }
            else
            {
                var slot = await _slotRepository.getByDoctorID(name);
                if(slot == null)
                    return new List<Slot> { };
                return slot;
            }
        }

        public async Task <Slot> GetBySlotID(string id)
        {
            return await _slotRepository.getBySlotID(id);
        }

        public async Task UpdateSlot(Slot slot)
        {
            await _slotRepository.UpdateSlot(slot);
        }
    }
}
