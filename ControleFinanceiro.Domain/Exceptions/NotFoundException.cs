using System.Runtime.Serialization;

namespace ControleFinanceiro.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : this("Registro não encontrado.") { }
        public NotFoundException(string message) : base(message) { }
        public NotFoundException(IEnumerable<string> messages) : base(string.Join(" ", messages)) { }
        public NotFoundException(string message, Exception innerException) : base(message, innerException) { }
        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
