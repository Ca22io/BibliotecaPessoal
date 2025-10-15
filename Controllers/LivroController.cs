using BibliotecaPessoal.Dto;
using BibliotecaPessoal.Models;
using BibliotecaPessoal.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

            var livros = await _livroService.ObterTodosLivros( ObterUsuario().Result.Id );

            return View(livros);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> CadastrarLivro()
        {

            ViewBag.Generos = ObterGeneros().Result;

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

            ViewBag.Generos = ObterGeneros().Result;

            return View(Livro);

        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> EditarLivro(int IdLivro)
        {
            var Existencia = await _livroService.VerificarSeExisteLivro(IdLivro, ObterUsuario().Result.Id);

            if (!Existencia)
            {
                return RedirectToAction("Index");
            }

            var Livro = await _livroService.ObterLivroComGenero(IdLivro, ObterUsuario().Result.Id);

            ViewBag.Generos = ObterGeneros().Result;

            return View(Livro);

        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditarLivro([FromForm] LivroEditarDto Livro)
        {
            if (ModelState.IsValid)
            {
                var Atualizar = await _livroService.AtualizarLivro(Livro);

                if (Atualizar == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Generos = ObterGeneros().Result;

                    return View(Livro);
                }
            }

            ViewBag.Generos = await ObterGeneros();
            
            return View(Livro);

        }

        private async Task<UsuarioModel> ObterUsuario()
        {
            return await _userManager.GetUserAsync(User);
        }

        private async Task<IEnumerable<GeneroDto>> ObterGeneros()
        {
            return await _generoService.ObterTodosGeneros();
        }
    }
}