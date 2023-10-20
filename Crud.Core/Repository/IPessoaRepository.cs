using Crud.Core.Model;

namespace Crud.Core.Repository
{
    public interface IPessoaRepository
    {
        IReadOnlyCollection<Pessoa> ListarTodos();

        void Salvar (Pessoa pessoa);

        void AtualizarPessoa(Pessoa pessoa);    

        void ExcluirPessoa(int id);
       
    }
}
