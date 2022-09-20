using AutoMapper;
using ControleFinanceiro.Domain.Dtos;
using ControleFinanceiro.Domain.Exceptions;
using ControleFinanceiro.Domain.Interfaces.Repositories;
using ControleFinanceiro.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

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
            var category = _mapper.Map<CategoryResponseDto>(_categoryRepository.GetById(id));
            if (category is null)
                throw new NotFoundException("Categoria não encontrada.");

            return category;
        }

        public void Add(CategoryRequestDto obj)
        {
            throw new NotImplementedException();
        }

        public void Update(CategoryRequestDto obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(CategoryRequestDto obj)
        {
            throw new NotImplementedException();
        }
    }
}
