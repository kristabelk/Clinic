using AppointmentSystem.Entities;

namespace AppointmentSystem.Repositories
{
    public class SlotRepositoryInMemory : ISlotRepository
    {
        private static readonly List<Slot> Slots = new List<Slot>();

        //private 

        public async Task Add(Slot slot)
        {
           // if(slot.Id == Guid.Empty)
           //     slot.Id = Guid.NewGuid();
            Slots.Add(slot);
           // return await "slot added";
            
           // throw new NotImplementedException();
        }

        public Task<List<Slot>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Slot>> GetAvailable()
        {
            throw new NotImplementedException();
        }

        public Task<List<Slot>> getByDoctorID(string? DocName)
        {
            throw new NotImplementedException();
        }

        public Task<List<Slot>> getByDoctorIDAvail(string? DocID)
        {
            throw new NotImplementedException();
        }

        public Task<Slot> getBySlotID(string SlotID)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSlot(Slot slot)
        {
            throw new NotImplementedException();
        }
    }
}
