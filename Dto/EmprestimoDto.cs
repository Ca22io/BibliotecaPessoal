namespace BibliotecaPessoal.Dto
{
    public class EmprestimoDto
    {
        public int IdEmprestimo { get; set; }

        public string? NomePessoa { get; set; }
        
        public required DateTime DataEmprestimo { get; set; }

        public DateTime? DataDevolucao { get; set; }

        public required int IdLivro { get; set; }

    }
}