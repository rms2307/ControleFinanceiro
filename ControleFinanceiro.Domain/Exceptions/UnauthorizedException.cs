using System.Runtime.Serialization;

namespace ControleFinanceiro.Domain.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException() : this("Não autenticado.") { }
        public UnauthorizedException(string message) : base(message) { }
        public UnauthorizedException(IEnumerable<string> messages) : base(string.Join(" ", messages)) { }
        public UnauthorizedException(string message, Exception innerException) : base(message, innerException) { }
        protected UnauthorizedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
