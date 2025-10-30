using AutoMapper;
using BibliotecaPessoal.Dto;
using BibliotecaPessoal.Models;
public class EmprestimoProfile : Profile
{
    public EmprestimoProfile()
    {
        CreateMap<EmprestimoModel, EmprestimoDto>();
    }
}