using AutoMapper;
using ControleFinanceiro.Domain.Dtos.Category;
using ControleFinanceiro.Domain.Dtos.CreditCard;
using ControleFinanceiro.Domain.Dtos.FixedSpend;
using ControleFinanceiro.Domain.Dtos.VariedSpend;
using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Application.Mappings
{
    public class DomainToDtoMappingProfile :Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Category, CategoryRequestDto>().ReverseMap();
            CreateMap<Category, CategoryResponseDto>().ReverseMap();

            CreateMap<VariedSpend,VariedSpendRequestDto>().ReverseMap();
            CreateMap<VariedSpend, VariedSpendResponseDto>().ReverseMap();
            
            CreateMap<FixedSpend, FixedSpendAddRequestDto>().ReverseMap();
            CreateMap<FixedSpend, FixedSpendEditRequestDto>().ReverseMap();
            CreateMap<FixedSpend, FixedSpendResponseDto>().ReverseMap();

            CreateMap<Spend, FixedSpendAddRequestDto>().ReverseMap();
            CreateMap<Spend, FixedSpendResponseDto>().ReverseMap();

            CreateMap<CreditCard, CreditCardRequestDto>().ReverseMap();
            CreateMap<CreditCard, CreditCardResponseDto>().ReverseMap();

            CreateMap<CreditCardSpend, CreditCardSpendRequestDto>().ReverseMap();
            CreateMap<CreditCardSpend, CreditCardSpendResponseDto>().ReverseMap();
        }
    }
}
