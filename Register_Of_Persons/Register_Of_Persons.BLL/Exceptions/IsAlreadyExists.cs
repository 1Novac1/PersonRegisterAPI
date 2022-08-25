using System;
using System.Runtime.Serialization;

namespace Register_Of_Persons.BLL.Exceptions
{
    [Serializable]
    public class IsAlreadyExists : Exception, ISerializable
    {
        public IsAlreadyExists() : base() { }
        public IsAlreadyExists(string message) : base(message) { }
        public IsAlreadyExists(string message, Exception inner) : base(message, inner) { }
        public IsAlreadyExists(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}