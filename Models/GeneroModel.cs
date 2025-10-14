using System.ComponentModel.DataAnnotations;

namespace BibliotecaPessoal.Models
{
    public class GeneroModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100), Required]
        public required string NomeGenero { get; set; }
    } 
}