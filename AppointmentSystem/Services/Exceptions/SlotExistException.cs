using System.Runtime.Serialization;

namespace AppointmentSystem.Services.Exceptions
{
    [Serializable]
    internal class SlotExistException : Exception
    {
        public SlotExistException()
        {
        }

        public SlotExistException(string? message) : base(message)
        {
        }

        public SlotExistException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected SlotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}