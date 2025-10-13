using BibliotecaPessoal.Service;
using BibliotecaPessoal.Dto;
using Microsoft.AspNetCore.Mvc;

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

                if (Resultado == true)
                {
                    return RedirectToAction("Index", "Home");
                }

                return RedirectToAction("Login", model);

            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _usuarioService.Logout();
            return RedirectToAction("Login");
        }
    }
}