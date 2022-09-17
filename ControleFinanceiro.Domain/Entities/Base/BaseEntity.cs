namespace ControleFinanceiro.Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }
        public DateTime DateLog { get; protected set; }
        public DateTime UserLog { get; protected set; }
    }
}