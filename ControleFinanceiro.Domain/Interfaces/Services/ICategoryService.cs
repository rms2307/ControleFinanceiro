using ControleFinanceiro.Domain.Dtos.Category;

namespace ControleFinanceiro.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        IEnumerable<CategoryResponseDto> GetAll();
        CategoryResponseDto GetById(int id);
        int Add(CategoryRequestDto dto);
        void Update(int id, CategoryRequestDto dto);
        void Delete(int id);
    }
}