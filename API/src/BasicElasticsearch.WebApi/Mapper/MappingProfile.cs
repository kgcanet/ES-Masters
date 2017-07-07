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

            CreateMap<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>().IgnoreAllPropertiesWithAnInaccessibleSetter().ReverseMap();
        }
    }
}
