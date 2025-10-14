using AutoMapper;
using BibliotecaPessoal.Dto;
using BibliotecaPessoal.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {   
        CreateMap<UsuarioCadastrarModelDto, UsuarioModel>();

        CreateMap<UsuarioModel, UsuarioAtualizarModelDto>();
    }
}