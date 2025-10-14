using BibliotecaPessoal.Service;
using BibliotecaPessoal.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BibliotecaPessoal.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromForm] UsuarioCadastrarModelDto model)
        {
            if (ModelState.IsValid)
            {
                var Resultado = await _usuarioService.Cadastrar(model);

                if (Resultado.Succeeded)
                {
                    return RedirectToAction("Login", "Usuario");
                }

                foreach (var error in Resultado.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model);

            }
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AtualizarCadastro(int id)
        {
            var usuario = await _usuarioService.ObterUsuarioPorId(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AtualizarCadastro([FromForm] UsuarioAtualizarModelDto model)
        {
            if (ModelState.IsValid)
            {
                var Resultado = await _usuarioService.AtualizarCadastro(model);

                if (Resultado.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in Resultado.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model);

            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult ExcluirUsuario()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ExcluirUsuario(int Id)
        {
            var Resultado = await _usuarioService.ExcluirUsuario(Id);

            if (Resultado.Succeeded)
            {
                return RedirectToAction("Login");
            }

            foreach (var error in Resultado.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginModelDto model)
        {
            if (ModelState.IsValid)
            {
                var Resultado = await _usuarioService.Login(model);

                if (Resultado.Succeeded)
                {
                    return RedirectToAction("Index", "Livro");
                }

                switch (Resultado)
                {
                    case var r when r.IsLockedOut:
                        ModelState.AddModelError(string.Empty, "Conta bloqueada. Tente novamente mais tarde.");
                        break;
                    case var r when r.IsNotAllowed:
                        ModelState.AddModelError(string.Empty, "Login não permitido. Verifique seu email.");
                        break;
                    case var r when r.RequiresTwoFactor:
                        ModelState.AddModelError(string.Empty, "Autenticação de dois fatores requerida.");
                        break;
                    default:
                        ModelState.AddModelError(string.Empty, "E-mail ou senha inválidos.");
                        break;
                }

                return View(model);

            }
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _usuarioService.Logout();
            return RedirectToAction("Login");
        }
    }
}