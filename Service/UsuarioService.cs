using AutoMapper;
using BibliotecaPessoal.Dto;
using BibliotecaPessoal.Models;
using Microsoft.AspNetCore.Identity;

namespace BibliotecaPessoal.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly SignInManager<UsuarioModel> _signInManager;
        private readonly IMapper _mapper;
        private readonly UserManager<UsuarioModel> _userManager;

        public UsuarioService(SignInManager<UsuarioModel> signInManager, IMapper mapper, UserManager<UsuarioModel> userManager)
        {
            _signInManager = signInManager;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<SignInResult> Login(LoginModelDto model)
        {
            var Resultado = await _signInManager.PasswordSignInAsync(model.Email, model.Senha, model.LembrarMe, false);

            return Resultado;
        }

        public async Task Logout()
            {
                await _signInManager.SignOutAsync();
            }

        public async Task<IdentityResult> Cadastrar(UsuarioCadastrarModelDto model)
        {
            var Usuario = _mapper.Map<UsuarioModel>(model);

            Usuario.UserName = model.Email;

            var Resultado = await _userManager.CreateAsync(Usuario, model.Password);

            return Resultado;
        }
    }
}