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


        public async Task<List<Slot>> getByDoctor(string? DocName)
        {
            return await _db.Slots.Where(x=> x.DoctorName == DocName).ToListAsync();
            
        }
    }
}
