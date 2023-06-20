using System.Runtime.Serialization;

namespace AppointmentSystem.Services.Exceptions
{
    [Serializable]
    internal class SlotException : Exception
    {
        public SlotException()
        {
        }

        public SlotException(string? message) : base(message)
        {
        }

        public SlotException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected SlotException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}