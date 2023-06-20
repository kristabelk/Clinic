using AppointmentSystem.Entities;

namespace AppointmentSystem.Repositories
{
    public class AppointmentRepositoryInMemory :IAppointmentRepository
    {
        private static readonly List<Appointment> Appointmentss = new List<Appointment>();

        public Task Add(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public bool AppointmentGUIDIsExist(Guid appointmentGUID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Appointment>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Appointment>> getByDocID(string? docID)
        {
            throw new NotImplementedException();
        }
    }
}
