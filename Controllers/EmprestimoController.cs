using BibliotecaPessoal.Dto;
using BibliotecaPessoal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaPessoal.Controllers
{
    public class EmprestimoController : Controller
    {
        private readonly UserManager<UsuarioModel> _userManager;

        public EmprestimoController(UserManager<UsuarioModel> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var usuario = await _userManager.GetUserAsync(User);
            if (usuario == null)
            {
                return Challenge();
            }

            // Lógica para obter a lista de empréstimos do usuário
            var emprestimos = new List<EmprestimoDto>
            {
                // Exemplo de dados fictícios
                new EmprestimoDto { IdEmprestimo = 1, NomePessoa = "João", DataEmprestimo = DateTime.Now.AddDays(-10), DataDevolucao = DateTime.Now.AddDays(5), IdLivro = 101, Status = "Emprestado" },
                new EmprestimoDto { IdEmprestimo = 2, NomePessoa = "Maria", DataEmprestimo = DateTime.Now.AddDays(-20), DataDevolucao = DateTime.Now.AddDays(-1), IdLivro = 102, Status = "Entregue" }
            };

            return View(emprestimos);
        }

    }
}