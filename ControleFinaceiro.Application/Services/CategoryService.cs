using AutoMapper;
using ControleFinanceiro.Domain.Dtos.Category;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Exceptions;
using ControleFinanceiro.Domain.Extensions;
using ControleFinanceiro.Domain.Interfaces.Repositories;
using ControleFinanceiro.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace ControleFinanceiro.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public IEnumerable<CategoryResponseDto> GetAll()
        {
            return _mapper.Map<IEnumerable<CategoryResponseDto>>(_categoryRepository.GetAll());
        }

        public CategoryResponseDto GetById(int id)
        {
            Category category = _categoryRepository.GetById(id);
            ValidateNull(category);

            return _mapper.Map<CategoryResponseDto>(category);
        }

        public int Add(CategoryRequestDto dto)
        {
            CheckIfNameExists(dto.Name);

            Category category = _mapper.Map<Category>(dto);
            _categoryRepository.Add(category);

            return category.Id;
        }

        public void Update(int id, CategoryRequestDto dto)
        {
            Category category = _categoryRepository.GetById(id);

            ValidateNull(category);
            CheckIfNameExists(dto.Name);

            category.Update(dto.Name);
            _categoryRepository.Update(category);
        }

        public void Delete(int id)
        {
            Category category = _categoryRepository.GetById(id);
            ValidateNull(category);

            _categoryRepository.Delete(category);
        }

        private static void ValidateNull(Category categoryDto)
        {
            if (categoryDto is null)
                throw new NotFoundException("Categoria não encontrada.");
        }

        private void CheckIfNameExists(string name)
        {
            string nameWithoutSpecialCharacters = name.RemoveSpecialCharacters().RemoveVowelAccent();

            IEnumerable<Category> categories = _categoryRepository.GetAll();

            if (categories.Any(c => c.Name.RemoveSpecialCharacters().RemoveVowelAccent() == nameWithoutSpecialCharacters))
                throw new ConflictException("Já existe uma categoria com esse nome.");
        }
    }
}
