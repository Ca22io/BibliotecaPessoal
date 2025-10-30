using AutoMapper;
using BibliotecaPessoal.Dto;
using BibliotecaPessoal.Models;

public class GeneroProfile : Profile
{
    public GeneroProfile()
    {
        CreateMap<GeneroModel, GeneroDto>();
    }
}
