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

    }
}