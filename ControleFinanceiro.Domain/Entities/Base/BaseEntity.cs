namespace ControleFinanceiro.Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }
        public string? UserLog { get; set; }
        public DateTime DateLog { get; set; }
    }
}