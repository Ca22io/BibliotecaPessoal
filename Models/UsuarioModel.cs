using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BibliotecaPessoal.Models
{
    public class UsuarioModel : IdentityUser<int>
    {
        [Required]
        public required string NomeCompleto { get; set;}
    }
}