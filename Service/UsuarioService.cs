using BibliotecaPessoal.Dto;
using Microsoft.AspNetCore.Identity;

namespace BibliotecaPessoal.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public UsuarioService(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<bool> Login(LoginModelDto model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Senha, model.LembrarMe, false);

            if (result.Succeeded)
            {
                return true;
            }

            return false;
        }

        public async Task Logout()
            {
                await _signInManager.SignOutAsync();
            }
    }
}