using BibliotecaPessoal.Dto;
using Microsoft.AspNetCore.Identity;

namespace BibliotecaPessoal.Service
{
    public interface IUsuarioService
    {
        Task<SignInResult> Login(LoginModelDto model);
        Task Logout();
        Task<IdentityResult> Cadastrar(UsuarioCadastrarModelDto model);
        Task<IdentityResult> AtualizarCadastro(UsuarioAtualizarModelDto model);
        Task<UsuarioAtualizarModelDto> ObterUsuarioPorId(int Id);
        Task<IdentityResult> ExcluirUsuario(int Id);
    }
}