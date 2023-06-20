using AppointmentSystem.Entities;

namespace AppointmentSystem.Repositories
{
    public interface ISlotRepository
    {
        public Task Add(Slot slot);
        public Task <List<Slot>> GetAll();
        public Task <List<Slot>> getByDoctorID(string? DocID);
        public Task<Slot> getBySlotID(string SlotID);
        public Task UpdateSlot(Slot slot);  
    }
}
