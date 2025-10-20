using FluentValidation;

namespace BibliotecaPessoal.Dto.Validators
{
    public class LivroEditarValidator : AbstractValidator<LivroEditarDto>
    {
        public LivroEditarValidator()
        {
            RuleFor(l => l.Autor)
                .NotEmpty().WithMessage("Autor é obrigatório!")
                .Length(2, 150).WithMessage("O nome do autor deve conter de 2 a 150 caracteres.");

            RuleFor(l => l.Titulo)
                .NotEmpty().WithMessage("O campo Título é obrigatório.")
                .Length(2, 200).WithMessage("O titulo deve conter de 2 a 200 caracteres.");
        }
        
    }
}