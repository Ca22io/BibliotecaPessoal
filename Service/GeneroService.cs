using AutoMapper;
using Biblioteca.Dto;
using BibliotecaPessoal.Data;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaPessoal.Service
{
    public class GeneroService : IGeneroService
    {
        private readonly ApplicationDbContext _context;

        private readonly IMapper _mapper;

        public GeneroService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GeneroDto>> ObterTodosGeneros()
        {
            var Generos = await _context.Generos.AsNoTracking().ToListAsync();

            return _mapper.Map<IEnumerable<GeneroDto>>(Generos);
        }
    }
}