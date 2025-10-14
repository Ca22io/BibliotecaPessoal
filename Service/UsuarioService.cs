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

        public async Task<UsuarioAtualizarModelDto> ObterUsuarioPorId(int Id)
        {
            var usuario = await _userManager.FindByIdAsync(Id.ToString());

            if (usuario == null)
            {
                return null;
            }

            return _mapper.Map<UsuarioAtualizarModelDto>(usuario);
        }

        public async Task<IdentityResult> AtualizarCadastro(UsuarioAtualizarModelDto model)
        {
            var usuario = await _userManager.FindByEmailAsync(model.Email);

            if (usuario == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Usuário não encontrado." });
            }

            usuario.NomeCompleto = model.NomeCompleto;
            usuario.Email = model.Email;
            usuario.UserName = model.Email;

            return await _userManager.UpdateAsync(usuario);
        }
        
        public async Task<IdentityResult> ExcluirUsuario(int Id)
        {
            var usuario = await _userManager.FindByIdAsync(Id.ToString());

            if (usuario == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Usuário não encontrado." });
            }

            await _signInManager.SignOutAsync();

            return await _userManager.DeleteAsync(usuario);
        }
    }
}