using BibliotecaPessoal.Dto;
using BibliotecaPessoal.Models;
using BibliotecaPessoal.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaPessoal.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroService _livroService;
        private readonly UserManager<UsuarioModel> _userManager;
        private readonly IGeneroService _generoService;

        public LivroController(ILivroService livroService, IGeneroService generoService, UserManager<UsuarioModel> userManager)
        {
            _livroService = livroService;
            _generoService = generoService;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {

            var ObterUsuario = await _userManager.GetUserAsync(User);

            var livros = await _livroService.ObterTodosLivros(ObterUsuario.Id);

            return View(livros);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> CadastrarLivro()
        {
            var generos = await _generoService.ObterTodosGeneros();

            ViewBag.Generos = generos;

            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CadastrarLivro(LivroDto Livro)
        {
            if (ModelState.IsValid)
            {
                var Resultado = await _livroService.CadastrarLivro(Livro);

                if (Resultado)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Ocorreu um erro ao cadastrar o livro.");
                }
            }

            return View(Livro);
            
        }
    }
}