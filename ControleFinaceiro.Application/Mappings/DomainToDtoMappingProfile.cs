using AutoMapper;
using ControleFinanceiro.Domain.Dtos;
using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Application.Mappings
{
    public class DomainToDtoMappingProfile :Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Category, CategoryRequestDto>();
            CreateMap<Category, CategoryResponseDto>();
        }
    }
}
