using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BibliotecaPessoal.Models
{
    public class LivroModel
    {
        [Key]
        public int IdLivro { get; set; }

        [StringLength(100), Required]
        public required string Titulo { get; set; }

        [StringLength(100), Required]
        public required string Autor { get; set; }

        [StringLength(50), Required]
        public string? CapaUrl { get; set; }

        [ForeignKey("Genero"), Required]
        public required int IdGenero { get; set; }

        [ForeignKey("Usuario"), Required]
        public required string IdUsuario { get; set; }

        public GeneroModel? Genero { get; set; }

        public IdentityUser? Usuario { get; set; }

    }
}