using BibliotecaPessoal.Dto;

namespace BibliotecaPessoal.Service
{
    public interface IUsuarioService
    {
        Task<bool> Login(LoginModelDto model);
        Task Logout();

        Task<bool> Cadastrar(UsuarioCadastrarModelDto model);
    }
}