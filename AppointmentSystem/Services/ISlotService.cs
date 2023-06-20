using AppointmentSystem.Entities;

namespace AppointmentSystem.Services
{
    public interface ISlotService
    {
        public Task CreateSlot(Slot slot);
        public Task <List<Slot>> GetAll(string?name);
        public Task <Slot> GetBySlotID(string slotID);
        public Task UpdateSlot(Slot slot);
    }
}
