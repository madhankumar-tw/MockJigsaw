using AutoMapper;
using MockJigsaw.Services.EmployeeAPI.Models;
using MockJigsaw.Services.EmployeeAPI.Models.Dto;

namespace MockJigsaw.Services.EmployeeAPI;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<EmployeeDto, Employee>();
            config.CreateMap<Employee, EmployeeDto>();
        });

        return mappingConfig;
    }
}