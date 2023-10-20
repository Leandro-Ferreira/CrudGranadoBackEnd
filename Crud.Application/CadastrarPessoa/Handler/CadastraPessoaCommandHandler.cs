using Crud.Application.CadastrarPessoa.Command;
using Crud.Core.Model;
using Crud.Core.Repository;
using MediatR;

namespace Crud.Application.CadastrarPessoa.Handler
{
    public class CadastraPessoaCommandHandler : IRequestHandler<CadastraPessoaCommand, string>
    {
        private readonly IPessoaRepository _repository;

        public CadastraPessoaCommandHandler(IPessoaRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(CadastraPessoaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Pessoa pessoa = new(request.Nome, request.Cpf, request.Email, request.Telefone);

                _repository.Salvar(pessoa);

                return await Task.FromResult("Cadastro realizado com sucesso");
            }
            catch(Exception ex) 
            {
                return await Task.FromResult(ex.Message);
            }
        }
    }
}
