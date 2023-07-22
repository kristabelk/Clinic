using AppointmentSystem.Database;
using AppointmentSystem.Entities;
using AppointmentSystem.Services.Exceptions;
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

        public async Task<List<Slot>> GetAvailable()
        {
            return await _db.Slots.Where(x => x.IsReserved == false).ToListAsync();
        }

        public async Task<List<Slot>> getByDoctorID(string? DocID)
        {
            return await _db.Slots.Where(x=> x.DoctorId.ToString() == DocID).ToListAsync();
            
        }

        public async Task<List<Slot>> getByDoctorIDAvail(string? DocID)
        {
          //  List<Slot> availslots = await _db.Slots.Where(x => x.IsReserved == false).ToListAsync();

           // return availslots.Where(x => x.DoctorId.ToString() == DocID).ToList();
           List<Slot> availSlots =await _db.Slots.Where(x => x.IsReserved == false).Where(x => x.DoctorId.ToString() == DocID).ToListAsync();
            return availSlots;

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
