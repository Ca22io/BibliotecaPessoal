namespace BibliotecaPessoal.Dto
{
    public class LivroDto
    {
        public int IdLivro { get; set; }

        public required string Titulo { get; set; }

        public required string Autor { get; set; }

        public string? CapaUrl { get; set; }

        public required int IdGenero { get; set; }

        public required string IdUsuario { get; set; }
    }
}