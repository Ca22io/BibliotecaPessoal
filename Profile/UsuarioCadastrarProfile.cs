using AutoMapper;
using BibliotecaPessoal.Dto;
using Microsoft.AspNetCore.Identity;

public class MappingProfile : Profile
{
    public MappingProfile()
    {   
        CreateMap<UsuarioCadastrarModelDto, IdentityUser>();

        CreateMap<IdentityUser, UsuarioAtualizarModelDto>();
    }
}