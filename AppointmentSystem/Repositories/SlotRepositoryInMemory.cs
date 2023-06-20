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

        public Task<List<Slot>> getByDoctor(string? DocName)
        {
            throw new NotImplementedException();
        }
    }
}
