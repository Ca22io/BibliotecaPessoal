using BibliotecaPessoal.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaPessoal.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroService _livroService;

        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index(string IdUsuario)
        {
            var livros = await _livroService.ObterTodosLivros(IdUsuario);
            return View(livros);
        }
    }
}