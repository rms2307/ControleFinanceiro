using ControleFinanceiro.Domain.Dtos;

namespace ControleFinanceiro.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        IEnumerable<CategoryResponseDto> GetAll();
        CategoryResponseDto GetById(int id);
        void Add(CategoryRequestDto obj);
        void Update(CategoryRequestDto obj);
        void Delete(CategoryRequestDto obj);
    }
}