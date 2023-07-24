using AppointmentSystem.Entities;
using AppointmentSystem.Repositories;
using AppointmentSystem.Services.Exceptions;

namespace AppointmentSystem.Services
{
    public class SlotService : ISlotService
    {
        private readonly ISlotRepository _slotRepository;
        private readonly ILogger<SlotService> _logger;
        public SlotService(ISlotRepository slotRepository, ILogger<SlotService> logger)
        {
            _slotRepository = slotRepository;
            _logger = logger;
        }
        public async Task CreateSlot(Slot slot)
        {
            if (slot.DoctorName == null)
                throw new SlotException();

            //check if slot exist 
            List<Slot> AllSlots = await _slotRepository.GetAll();
            if(AllSlots.Where(x=>x.DoctorId==slot.DoctorId).Count()>0 && AllSlots.Where(x=>x.Date == slot.Date).Count()>0)
            {
                _logger.LogError("Slot Exist");
                throw new SlotExistException();
            }
            else
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

        public async Task<List<Slot>> GetAvailable(string? name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return await _slotRepository.GetAvailable();
                //throw new CategoryNameEmptyException();
            }
            else
            {
                var slot = await _slotRepository.getByDoctorIDAvail(name);
                if (slot == null)
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
