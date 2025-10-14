using BibliotecaPessoal.Dto;
using Microsoft.AspNetCore.Identity;

namespace BibliotecaPessoal.Service
{
    public interface IUsuarioService
    {
        Task<SignInResult> Login(LoginModelDto model);
        Task Logout();
        Task<IdentityResult> Cadastrar(UsuarioCadastrarModelDto model);
    }
}