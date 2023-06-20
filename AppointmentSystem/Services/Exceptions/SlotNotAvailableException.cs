using System.Runtime.Serialization;

namespace AppointmentSystem.Services.Exceptions
{
    [Serializable]
    internal class SlotNotAvailableException : Exception
    {
        public SlotNotAvailableException()
        {
        }

        public SlotNotAvailableException(string? message) : base(message)
        {
        }

        public SlotNotAvailableException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected SlotNotAvailableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}