using ControleFinanceiro.Domain.Dtos.CreditCard;

namespace ControleFinanceiro.Domain.Interfaces.Services
{
    public interface ICreditCardService
    {
        IEnumerable<CreditCardResponseDto> GetAll();
        CreditCardResponseDto GetById(int id);
        int Add(CreditCardRequestDto dto);
        void Update(int id, CreditCardRequestDto dto);
        void Delete(int id);
    }
}