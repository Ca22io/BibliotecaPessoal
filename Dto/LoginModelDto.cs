namespace BibliotecaPessoal.Dto
{
    public class LoginModelDto
    {
        public required string Email { get; set; }
        public required string Senha { get; set; }
        public required bool LembrarMe { get; set; }
    }
}