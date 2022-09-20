using AutoMapper;
using ControleFinanceiro.Domain.Dtos.Category;
using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Application.Mappings
{
    public class DomainToDtoMappingProfile :Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Category, CategoryRequestDto>().ReverseMap();
            CreateMap<Category, CategoryResponseDto>().ReverseMap();
        }
    }
}
