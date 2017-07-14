using AutoMapper;
using BasicElasticsearch.WebApi.Models;
using BasicElasticsearch.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicElasticsearch.WebApi.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeViewModel,Employee>()//.IgnoreAllPropertiesWithAnInaccessibleSetter().ReverseMap();
                .ForMember(desti => desti.IsActive, source => source.MapFrom(a => a.IsActive == "1"? true : false))
                .ForMember(desti => desti.HasPassport, source => source.MapFrom(a => a.HasPassport == "1" ? true : false))
                .ForMember(desti => desti.HasVisa, source => source.MapFrom(a => a.HasVisa == "1" ? true : false))
                .ForMember(desti => desti.IsEmployed, source => source.MapFrom(a => a.IsEmployed == "1" ? true : false))
                .ForMember(desti => desti.EmployeeID, source => source.MapFrom(a => Convert.ToInt32( a.EmployeeID) ))
                .ForMember(desti => desti.EmployeeNumber, source => source.MapFrom(a => a.EmployeeNumber.Trim())).ReverseMap();

            CreateMap<PassportViewModel, Passport>().ReverseMap();

            CreateMap<PositionViewModel, Position>().ReverseMap();

            CreateMap<VisaStatusViewModel, VisaStatus>().ReverseMap();

            CreateMap<VisaTypeViewModel, VisaType>().ReverseMap();

            CreateMap<SearchViewModel, Search>().ReverseMap();

            CreateMap<VisaViewModel, Visa>()//.IgnoreAllPropertiesWithAnInaccessibleSetter().ReverseMap();
                .ForMember(desti => desti.IsMultipleEntry, source => source.MapFrom(a => a.IsMultipleEntry == "1" ? true : false))
                .ForMember(desti => desti.EmployeeVisaID, source => source.MapFrom(a => Convert.ToInt32(a.EmployeeVisaID)))
                .ForMember(desti => desti.EmployeeID, source => source.MapFrom(a => Convert.ToInt32(a.EmployeeID)))
                .ForMember(desti => desti.VisaTypeID, source => source.MapFrom(a => Convert.ToInt32(a.VisaTypeID)))
                .ForMember(desti => desti.VisaStatusID, source => source.MapFrom(a => Convert.ToInt32(a.VisaStatusID)))
                .ForMember(desti => desti.EmployeeVisaID, source => source.MapFrom(a => a.EmployeeVisaID.Trim())).ReverseMap();

        }
    }
}
