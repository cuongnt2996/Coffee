using AutoMapper;
using Coffee.Models;
using Coffee.Models.DTOs;
namespace Coffee.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // CreateMap<Employee, EmployeeDto>()
        // .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
        // .ReverseMap()
        // .ForMember(dest => dest.FirstName,
        //         opt => opt.MapFrom(src => src.FullName.Split(' ')[0]))
        //         .ForMember(dest => dest.LastName,
        //                opt => opt.MapFrom(src => src.FullName.Split(' ').Length > 1
        //                                          ? src.FullName.Split(' ')[1]
        //                                          : string.Empty));

    CreateMap<Employee, EmployeeDto>()
        .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
        .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src=> src.Status !=null ? src.Status.StatusName : string.Empty))
        .ReverseMap()
        .ForMember(dest => dest.FirstName,
                opt => opt.MapFrom(src =>
                    string.IsNullOrWhiteSpace(src.FullName)
                        ? string.Empty
                        : src.FullName.Split(' ', StringSplitOptions.RemoveEmptyEntries).First()))
        .ForMember(dest => dest.LastName,
                opt => opt.MapFrom(src =>
                    string.IsNullOrWhiteSpace(src.FullName)
                        ? string.Empty
                        : string.Join(" ",
                            src.FullName.Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1))));

        CreateMap<Employee, CreateEmployeeRequest>().ReverseMap();

        CreateMap<Employee, UpdateEmployeeRequest>().ReverseMap();
    
        

    }
}