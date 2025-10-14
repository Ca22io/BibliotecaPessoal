using BibliotecaPessoal.Dto;

namespace BibliotecaPessoal.Service
{
    public interface ILivroService
    {
        Task<bool> CadastrarLivro(LivroDto Livro);

        Task<bool> AtualizarLivro(LivroDto Livro);

        Task<bool> RemoverLivro(int IdLivro, int IdUsuario);

        Task<LivroDto> ObterLivroPorId(int IdLivro, int IdUsuario);

        Task<IEnumerable<LivroDto>> ObterTodosLivros(int IdUsuario);

    }
}