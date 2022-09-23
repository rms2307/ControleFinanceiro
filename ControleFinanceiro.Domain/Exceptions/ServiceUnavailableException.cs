using System.Runtime.Serialization;

namespace ControleFinanceiro.Domain.Exceptions
{
    public class ServiceUnavailableException : Exception
    {
        public ServiceUnavailableException() : this("Serviço indisponível.") { }
        public ServiceUnavailableException(string message) : base(message) { }
        public ServiceUnavailableException(IEnumerable<string> messages) : base(string.Join(" ", messages)) { }
        public ServiceUnavailableException(string message, Exception innerException) : base(message, innerException) { }
        protected ServiceUnavailableException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
