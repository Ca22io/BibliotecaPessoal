
using AutoMapper;
using BibliotecaPessoal.Dto;
using BibliotecaPessoal.Models;

public class LivroProfile : Profile
    {
        public LivroProfile()
        {
            CreateMap<LivroModel, LivroDto>();

            CreateMap<LivroDto, LivroModel>();

            CreateMap<LivroEditarDto, LivroModel>();
                
        }
    }
