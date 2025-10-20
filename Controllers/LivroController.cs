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

            var livros = await _livroService.ObterTodosLivros(ObterUsuario().Result.Id);

            return View(livros);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> DetalhesLivro(int IdLivro)
        {
            var ObterLivro = await _livroService.ObterLivroComGenero(IdLivro, ObterUsuario().Result.Id);

            return View(ObterLivro);
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
                    TempData["Mensagem"] = MensagemPartial.Serealizar("Livro cadastrado com sucesso", TipoMensagem.Sucesso);

                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Mensagem"] = MensagemPartial.Serealizar("Ocorreu um erro ao cadastrar o livro! Se perisitir entre em contato com o suporte.", TipoMensagem.Erro);

                    ViewBag.Generos = ObterGeneros().Result;

                    return View(Livro);
                }
            }

            TempData["Mensagem"] = MensagemPartial.Serealizar("Algo está errado, tente novamente! Se perisitir entre em contato com o suporte.", TipoMensagem.Informacao);

            ViewBag.Generos = ObterGeneros().Result;

            return View(Livro);

        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> EditarLivro(int IdLivro)
        {
            // var Existencia = await _livroService.VerificarSeExisteLivro(IdLivro, ObterUsuario().Result.Id);

            // if (!Existencia)
            // {
            //     TempData["Mensagem"] = MensagemPartial.Serealizar("Livro não encontrado! Se perisitir entre em contato com o suporte.", TipoMensagem.Informacao);

            //     return RedirectToAction("Index");
            // }

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
                    TempData["Mensagem"] = MensagemPartial.Serealizar("Livro atualizado com sucesso", TipoMensagem.Sucesso);

                    return RedirectToAction("DetalhesLivro", new { IdLivro = Livro.IdLivro });
                }
                else
                {
                    TempData["Mensagem"] = MensagemPartial.Serealizar("Ocorreu um erro ao atualizar o livro! Se perisitir entre em contato com o suporte.", TipoMensagem.Erro);

                    return RedirectToAction("EditarLivro", new { IdLivro = Livro.IdLivro });
                }
            }

            TempData["Mensagem"] = MensagemPartial.Serealizar("Algo está errado, tente novamente! Se perisitir entre em contato com o suporte.", TipoMensagem.Informacao);

            return RedirectToAction("EditarLivro", new { IdLivro = Livro.IdLivro });

        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ExcluirLivro(int IdLivro)
        {
            var ObterLivro = await _livroService.ObterLivroPorId(IdLivro, ObterUsuario().Result.Id);

            return View(ObterLivro);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Excluir ([FromForm] int IdLivro)
        {
            var Resultado = await _livroService.ExcluirLivro(IdLivro, ObterUsuario().Result.Id);

            if (Resultado)
            {
                TempData["Mensagem"] = MensagemPartial.Serealizar("Livro excluido com sucesso!", TipoMensagem.Sucesso);

                return RedirectToAction("Index");
            }

            TempData["Mensagem"] = MensagemPartial.Serealizar("Ocorreu um erro ao excluir o livro! Se perisitir entre em contato com o suporte.", TipoMensagem.Erro);

            return RedirectToAction("DetalhesLivro", new { IdLivro = IdLivro });
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