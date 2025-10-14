using Biblioteca.Dto;

namespace BibliotecaPessoal.Service
{
    public interface IGeneroService
    {
        Task<IEnumerable<GeneroDto>> ObterTodosGeneros();
    }
}