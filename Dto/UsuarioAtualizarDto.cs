namespace BibliotecaPessoal.Dto
{
    public class UsuarioAtualizarModelDto
    {
        public required string Id { get; set; }
        public required string NomeCompleto { get; set; }
        public required string Email { get; set; }
    }
}