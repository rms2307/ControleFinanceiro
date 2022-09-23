using System.Runtime.Serialization;

namespace ControleFinanceiro.Domain.Exceptions
{
    public class ConflictException : Exception
    {
        public ConflictException() : this("Conflito.") { }
        public ConflictException(string message) : base(message) { }
        public ConflictException(IEnumerable<string> messages) : base(string.Join(" ", messages)) { }
        public ConflictException(string message, Exception innerException) : base(message, innerException) { }
        protected ConflictException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
