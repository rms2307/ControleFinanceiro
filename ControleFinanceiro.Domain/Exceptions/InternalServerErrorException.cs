using System.Runtime.Serialization;

namespace ControleFinanceiro.Domain.Exceptions
{
    public class InternalServerErrorException : Exception
    {
        public InternalServerErrorException() : this("Ocorreu um erro interno, tente novamente mais tarde ou contate o suporte técnico.") { }
        public InternalServerErrorException(string message) : base(message) { }
        public InternalServerErrorException(IEnumerable<string> messages) : base(string.Join(" ", messages)) { }
        public InternalServerErrorException(string message, Exception innerException) : base(message, innerException) { }
        protected InternalServerErrorException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
