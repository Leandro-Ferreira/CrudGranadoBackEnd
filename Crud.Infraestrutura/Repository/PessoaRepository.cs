using Crud.Core.Model;
using Crud.Core.Repository;
using Crud.Infraestrutura.Data;

namespace Crud.Infraestrutura.Repository
{
    public class PessoaRepository : IPessoaRepository
    {

        private readonly CrudGranadoContext _context;

        public PessoaRepository(CrudGranadoContext context)
        {
            _context = context;     
        }

        public void AtualizarPessoa(Pessoa pessoa)
        {
            _context.Pessoas.Update(pessoa);
            _context.SaveChanges();
        }

        public void ExcluirPessoa(int id)
        {

            var pessoa = _context.Pessoas.Where(p => p.Id == id)
                .First() ?? throw new Exception("Não foi encontrada nenhuma pessoa com esse Id");
            
            _context.Pessoas.Remove(pessoa);
            _context.SaveChanges();
        }

        public IReadOnlyCollection<Pessoa> ListarTodos()
        {
            return _context.Pessoas.ToList();
        }

        public void Salvar(Pessoa pessoa)
        {
            try
            {
                _context.Pessoas.Add(pessoa);
                _context.SaveChanges();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
