using BibliotecaPessoal.Dto;

namespace BibliotecaPessoal.Service
{
    public interface IEmprestimoService
    {
        void RegistrarEmprestimo(EmprestimoDto emprestimo);
        void RegistrarDevolucao(int emprestimoId, DateTime dataDevolucao);
        void EditarEmprestimo(EmprestimoDto emprestimo);
        IEnumerable<EmprestimoDto> ObterEmprestimosAtivos();
        IEnumerable<EmprestimoDto> ObterHistoricoEmprestimos(int usuarioId);
    }
}