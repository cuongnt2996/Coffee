using AutoMapper;
using Coffee.Models;
using Coffee.Models.DTOs;
namespace Coffee.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Employee, EmployeeDto>().ReverseMap();
    }
}