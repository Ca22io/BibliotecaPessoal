using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaPessoal.Models
{
    public class EmprestimoModel
    {
        [Key, Required]
        public int IdEmprestimo { get; set; }

        [StringLength(100), Required]
        public required string NomePessoa { get; set; }
        
        [Required, DataType(DataType.Date)]
        public required DateTime DataEmprestimo { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataDevolucao { get; set; }

        [ForeignKey("Livro"), Required]
        public required int IdLivro { get; set; }

        [NotMapped]
        public LivroModel? Livro { get; set; }
    }
}