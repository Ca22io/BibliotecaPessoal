using System.ComponentModel.DataAnnotations;

namespace BibliotecaPessoal.Dto
{
    public class UsuarioCadastrarModelDto
    {
        public required string NomeCompleto { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

        [Compare("Password", ErrorMessage = "As senhas não Conferem")]
        public required string ConfirmPassword { get; set; }
    }
}