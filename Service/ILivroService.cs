using BibliotecaPessoal.Dto;

namespace BibliotecaPessoal.Service
{
    public interface ILivroService
    {
        Task<bool> AdicionarLivro(LivroDto Livro);

        Task<bool> AtualizarLivro(LivroDto Livro);

        Task<bool> RemoverLivro(int IdLivro, int IdUsuario);

        Task<LivroDto> ObterLivroPorId(int IdLivro, int IdUsuario);

        Task<IEnumerable<LivroDto>> ObterTodosLivros(string IdUsuario);

    }
}