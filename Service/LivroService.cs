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

        private readonly IWebHostEnvironment _hostEnvironment;

        private readonly ApplicationDbContext _context;

        public LivroService(ApplicationDbContext context, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<bool> CadastrarLivro(LivroDto Livro)
        {
            if (Livro.CapaArquivo != null && Livro.CapaArquivo.Length != 0)
            {
                 // Pasta onde as imagens serão salvas (ex: wwwroot/images/capas)
                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images", "capas"); 
                
                // Garante que a pasta exista
                if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

                // Gera um nome de arquivo único para evitar colisões
                string nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(Livro.CapaArquivo.FileName);
                string caminhoCompleto = Path.Combine(uploadsFolder, nomeArquivo);

                // 2. SALVAR O ARQUIVO FISICAMENTE NO SERVIDOR
                using (var fileStream = new FileStream(caminhoCompleto, FileMode.Create)) 
                {
                    await Livro.CapaArquivo.CopyToAsync(fileStream);
                }

                Livro.CapaUrl = Path.Combine("/images/capas", nomeArquivo).Replace('\\', '/');
            }

            var ConverterLivro = _mapper.Map<LivroModel>(Livro);

            await _context.Livros.AddAsync(ConverterLivro);

            var SalvarLivro = await _context.SaveChangesAsync();

            if (SalvarLivro > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> AtualizarLivro(LivroEditarDto Livro)
        {
            if (Livro.CapaArquivo != null)
            {
                 // Pasta onde as imagens serão salvas (ex: wwwroot/images/capas)
                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images", "capas"); 
                
                // Garante que a pasta exista
                if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

                // Gera um nome de arquivo único para evitar colisões
                string nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(Livro.CapaArquivo.FileName);
                string caminhoCompleto = Path.Combine(uploadsFolder, nomeArquivo);

                // 2. SALVAR O ARQUIVO FISICAMENTE NO SERVIDOR
                using (var fileStream = new FileStream(caminhoCompleto, FileMode.Create)) 
                {
                    await Livro.CapaArquivo.CopyToAsync(fileStream);
                }

                Livro.CapaUrl = Path.Combine("/images/capas", nomeArquivo).Replace('\\', '/');
            }

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
            var Livro = await _context.Livros.Where(l => l.IdLivro == IdLivro && l.IdUsuario == IdUsuario)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (Livro == null)
            {
                return null;
            }

            return _mapper.Map<LivroDto>(Livro);
        }

        public async Task<IEnumerable<LivroDto>> ObterTodosLivros(int IdUsuario)
        {
            
            var Livros = await _context.Livros.AsNoTracking().Where(x => x.IdUsuario == IdUsuario).ToListAsync();

            return _mapper.Map<IEnumerable<LivroDto>>(Livros);
        }

        public async Task<bool> ExcluirLivro(int IdLivro, int IdUsuario)
        {
            var Livro = await _context.Livros.Where(l => l.IdLivro == IdLivro && l.IdUsuario == IdUsuario)
                .FirstOrDefaultAsync();

            if (Livro == null)
            {
                return false;
            }

            _context.Livros.Remove(Livro);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<LivroEditarDto> ObterLivroComGenero(int IdLivro, int IdUsuario)
        {
            var Livro = await _context.Livros
                .Where(l => l.IdLivro == IdLivro && l.IdUsuario == IdUsuario)
                .Include(g => g.Genero)
                .Select(l => new LivroEditarDto
                {
                    NomeGenero = l.Genero.NomeGenero,
                    Titulo = l.Titulo,
                    Autor = l.Autor,
                    CapaUrl = l.CapaUrl,
                    IdGenero = l.IdGenero,
                    IdLivro = l.IdLivro,
                    IdUsuario = l.IdUsuario
                }
                )
                .AsNoTracking().FirstOrDefaultAsync();

            if (Livro != null)
            {
                return Livro;
            }
            else
            {
                return new LivroEditarDto();
            }

        }

        public async Task<bool> VerificarSeExisteLivro(int IdLivro, int IdUsuario)
        {
            return await _context.Livros.AnyAsync(l => l.IdLivro == IdUsuario && l.IdUsuario == IdUsuario);
        }
    }
}