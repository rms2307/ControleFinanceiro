using System.Runtime.Serialization;

namespace ControleFinanceiro.Domain.Exceptions
{
    public class BadRequestException : Exception
    {
        private static string _message = string.Empty;

        public BadRequestException() : this("Dados de requisição inválidos.") { }
        public BadRequestException(string message) : base(message) { }
        public BadRequestException(IEnumerable<string> messages) : base(_message) => _message = string.Join(" ", messages);
        public BadRequestException(string message, Exception innerException) : base(message, innerException) { }
        protected BadRequestException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }
}
