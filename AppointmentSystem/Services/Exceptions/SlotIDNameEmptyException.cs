namespace AppointmentSystem.Services.Exceptions
{
    [Serializable]
    internal class SlotIDNameEmptyException : Exception
    {
        public SlotIDNameEmptyException() :base("Slot ID shound not be empty")
        {
        }

        
    }
}