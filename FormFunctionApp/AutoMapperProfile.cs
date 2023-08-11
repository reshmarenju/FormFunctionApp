using AutoMapper;
using FormFunctionApp.Models;
using FormFunctionApp.Dtos;

// ...

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<FormDto, Form>();

        CreateMap<RobDto, Rob>();

    }
}