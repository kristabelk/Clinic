using AppointmentSystem.Database;
using AppointmentSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystem.Repositories
{
    public class SlotRepo :ISlotRepository
    {
        private ClinicDatabase _db;
        public SlotRepo(ClinicDatabase db) 
        { 
            _db = db;
        }

        public async Task Add(Slot slot)
        {
            _db.Slots.Add(slot);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Slot>> GetAll()
        {
            return _db.Slots.ToList();// return Slots; 
        }


        public async Task<List<Slot>> getByDoctorID(string? DocID)
        {
            return await _db.Slots.Where(x=> x.DoctorId.ToString() == DocID).ToListAsync();
            
        }

        public async Task<Slot?> getBySlotID(string SlotID)
        {
            return await _db.Slots.Where(x=> x.Id.ToString() == SlotID).SingleOrDefaultAsync();
        }

        public async Task UpdateSlot(Slot slot)
        {
            slot.IsReserved = !slot.IsReserved;
            _db.Slots.Update(slot);
            await _db.SaveChangesAsync();

        }
    }
}
