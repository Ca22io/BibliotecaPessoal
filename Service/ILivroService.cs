using BibliotecaPessoal.Dto;

namespace BibliotecaPessoal.Service
{
    public interface ILivroService
    {
        Task<bool> CadastrarLivro(LivroDto Livro);

        Task<bool> AtualizarLivro(LivroEditarDto Livro);

        Task<bool> ExcluirLivro(int IdLivro, int IdUsuario);

        Task<LivroDto> ObterLivroPorId(int IdLivro, int IdUsuario);

        Task<LivroEditarDto> ObterLivroComGenero(int IdLivro, int IdUsuario);

        Task<IEnumerable<LivroDto>> ObterTodosLivros(int IdUsuario);

        Task<bool> VerificarSeExisteLivro(int IdLivro, int IdUsuario);

    }
}