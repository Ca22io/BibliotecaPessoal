using AutoMapper;
using Biblioteca.Dto;
using BibliotecaPessoal.Models;


public class GeneroProfile : Profile
{
    public GeneroProfile()
    {
        CreateMap<GeneroModel, GeneroDto>();
    }
}
