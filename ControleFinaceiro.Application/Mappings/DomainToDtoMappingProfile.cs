using AutoMapper;
using ControleFinanceiro.Domain.Dtos.Category;
using ControleFinanceiro.Domain.Dtos.FixedCost;
using ControleFinanceiro.Domain.Dtos.VariedCost;
using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Application.Mappings
{
    public class DomainToDtoMappingProfile :Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Category, CategoryRequestDto>().ReverseMap();
            CreateMap<Category, CategoryResponseDto>().ReverseMap();

            CreateMap<VariedCost,VariedCostRequestDto>().ReverseMap();
            CreateMap<VariedCost, VariedCostResponseDto>().ReverseMap();
            
            CreateMap<FixedCost, FixedCostAddRequestDto>().ReverseMap();
            CreateMap<FixedCost, FixedCostEditRequestDto>().ReverseMap();
            CreateMap<FixedCost, FixedCostResponseDto>().ReverseMap();

            CreateMap<Cost, FixedCostAddRequestDto>().ReverseMap();
            CreateMap<Cost, FixedCostResponseDto>().ReverseMap();
        }
    }
}
