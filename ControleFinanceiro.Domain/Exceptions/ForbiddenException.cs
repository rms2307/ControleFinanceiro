using System.Runtime.Serialization;

namespace ControleFinanceiro.Domain.Exceptions
{
    public class ForbiddenException : Exception
    {
        public ForbiddenException() : this("Não autorizado.") { }
        public ForbiddenException(string message) : base(message) { }
        public ForbiddenException(IEnumerable<string> messages) : base(string.Join(" ", messages)) { }
        public ForbiddenException(string message, Exception innerException) : base(message, innerException) { }
        protected ForbiddenException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
