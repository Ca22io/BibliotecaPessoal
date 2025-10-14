using AutoMapper;
using BibliotecaPessoal.Data;
using BibliotecaPessoal.Dto;
using BibliotecaPessoal.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaPessoal.Service
{
    public class LivroService : ILivroService
    {
        private readonly IMapper _mapper;

        private readonly ApplicationDbContext _context;

        public LivroService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AdicionarLivro(LivroDto Livro)
        {
            var ConverterLivro = _mapper.Map<LivroModel>(Livro);

            await _context.Livros.AddAsync(ConverterLivro);

            var SalvarLivro = await _context.SaveChangesAsync();

            if (SalvarLivro > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> AtualizarLivro(LivroDto Livro)
        {
            var ConverterLivro = _mapper.Map<LivroModel>(Livro);

            _context.Livros.Update(ConverterLivro);

            var SalvarLivro = await _context.SaveChangesAsync();

            if (SalvarLivro > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<LivroDto> ObterLivroPorId(int IdLivro, int IdUsuario)
        {
            var Livro = await _context.Livros.FindAsync(IdLivro, IdUsuario);

            if (Livro == null)
            {
                return null;
            }

            return _mapper.Map<LivroDto>(Livro);
        }

        public async Task<IEnumerable<LivroDto>> ObterTodosLivros(string IdUsuario)
        {
            var Livros = await _context.Livros.AsNoTracking().Where(x => x.IdUsuario == IdUsuario).ToListAsync();

            return _mapper.Map<IEnumerable<LivroDto>>(Livros);
        }

        public async Task<bool> RemoverLivro(int IdLivro, int IdUsuario)
        {
            var Livro = await _context.Livros.FindAsync(IdLivro, IdUsuario);

            if (Livro == null)
            {
                return false;
            }

            _context.Livros.Remove(Livro);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}