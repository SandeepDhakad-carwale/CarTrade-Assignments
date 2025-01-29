using AutoMapper;
using Cars.BLL.DTOs;
using Cars.Domains;
using Cars.BLL.Helpers;



namespace Cars.BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           CreateMap<QueryDTO, Filters>()
            .ForMember(dest => dest.FuelTypes, opt => opt.MapFrom(src =>
                QueryHelpers.ParseFuelQuery(src.Fuel)
            ))
            .ForMember(dest => dest.MinBudget, opt => opt.MapFrom(src => QueryHelpers.ParseBudgetRange(src.Budget).MinBudget))
            .ForMember(dest => dest.MaxBudget, opt => opt.MapFrom(src => QueryHelpers.ParseBudgetRange(src.Budget).MaxBudget));
       
       CreateMap<Stock, StockDTO>()
                     .ForMember(dest => dest.FormattedPrice,
                         opt => opt.MapFrom(src => $"Rs. {src.Price} Lakh"))
                     .ForMember(dest => dest.CarName,
                         opt => opt.MapFrom(src => $"{src.MakeYear} {src.MakeName} {src.ModelName}"));
       

        CreateMap<InputDTO, Stock>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.FuelType, opt => opt.MapFrom(src => src.FuelType))
                .ForMember(dest => dest.Kms, opt => opt.MapFrom(src => src.Kms))
                .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.ModelName))
                .ForMember(dest => dest.MakeYear, opt => opt.MapFrom(src => src.MakeYear))
                .ForMember(dest => dest.MakeName, opt => opt.MapFrom(src => src.MakeName));
        }
        }

        
    }

        