using BibliotecaPessoal.Dto;

namespace BibliotecaPessoal.Service
{
    public class EmprestimoService : IEmprestimoService
    {
        public void EditarEmprestimo(EmprestimoDto emprestimo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmprestimoDto> ObterEmprestimosAtivos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmprestimoDto> ObterHistoricoEmprestimos(int usuarioId)
        {
            throw new NotImplementedException();
        }

        public void RegistrarDevolucao(int emprestimoId, DateTime dataDevolucao)
        {
            throw new NotImplementedException();
        }

        public void RegistrarEmprestimo(EmprestimoDto emprestimo)
        {
            throw new NotImplementedException();
        }
    }
}