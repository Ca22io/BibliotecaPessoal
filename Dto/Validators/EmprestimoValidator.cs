using FluentValidation;

namespace BibliotecaPessoal.Dto.Validators
{
    public class EmprestimoValidator : AbstractValidator<EmprestimoDto>
    {
        public EmprestimoValidator()
        {
            RuleFor(e => e.DataEmprestimo)
                .NotEmpty().WithMessage("A data do empréstimo é obrigatória!")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data do empréstimo não pode ser no futuro.");

            RuleFor(e => e.IdLivro)
                .NotEmpty().WithMessage("O empréstimo deve estar vinculado a um livro!")
                .GreaterThan(0).WithMessage("O Id do livro deve ser maior que zero.");

            RuleFor(e => e.DataDevolucao)
                .GreaterThan(e => e.DataEmprestimo).WithMessage("A data de devolução deve ser posterior à data de empréstimo.")
                .When(e => e.DataDevolucao.HasValue);

            RuleFor(e => e.NomePessoa)
                .NotEmpty().WithMessage("O nome da pessoa é obrigatório!")
                .MaximumLength(100).WithMessage("O nome da pessoa não pode exceder 100 caracteres.");

        }
        
    }
}