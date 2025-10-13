using AutoMapper;
using BibliotecaPessoal.Dto;
using Microsoft.AspNetCore.Identity;

namespace BibliotecaPessoal.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public UsuarioService(SignInManager<IdentityUser> signInManager, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<bool> Login(LoginModelDto model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Senha, model.LembrarMe, false);

            return result.Succeeded;
        }

        public async Task Logout()
            {
                await _signInManager.SignOutAsync();
            }

        public async Task<bool> Cadastrar(UsuarioCadastrarModelDto model)
        {
            var Usuario = _mapper.Map<IdentityUser>(model);

            var Resultado = await _userManager.CreateAsync(Usuario, model.Password);

            if (Resultado.Succeeded)
            {
                return true;
            }

            return false;
        }
    }
}