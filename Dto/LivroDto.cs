namespace BibliotecaPessoal.Dto
{
    public class LivroDto
    {
        public int IdLivro { get; set; }

        public string? Titulo { get; set; }

        public string? Autor { get; set; }

        public string? CapaUrl { get; set; }

        public IFormFile? CapaArquivo { get; set; }

        public int IdGenero { get; set; }

        public int IdUsuario { get; set; }
    }
}