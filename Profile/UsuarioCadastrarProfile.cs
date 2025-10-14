using AutoMapper;
using BibliotecaPessoal.Dto;
using BibliotecaPessoal.Models;
using Microsoft.AspNetCore.Identity;

public class MappingProfile : Profile
{
    public MappingProfile()
    {   
        CreateMap<UsuarioCadastrarModelDto, UsuarioModel>();

        CreateMap<UsuarioModel, UsuarioAtualizarModelDto>();
    }
}