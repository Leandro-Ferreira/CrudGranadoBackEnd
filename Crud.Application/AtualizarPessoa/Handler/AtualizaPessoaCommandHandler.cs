using Crud.Application.AtualizarPessoa.Command;
using Crud.Core.Model;
using Crud.Core.Repository;
using MediatR;

namespace Crud.Application.AtualizarPessoa.Handler
{
    public class AtualizaPessoaCommandHandler : IRequestHandler<AtualizaPessoaCommand, string>
    {
        private readonly IPessoaRepository _repository;

        public AtualizaPessoaCommandHandler(IPessoaRepository repository)
        {
            _repository = repository;
        }

        public Task<string> Handle(AtualizaPessoaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Pessoa pessoa = new(request.Id, request.Nome, request.Cpf, request.Email, request.Telefone);

                _repository.AtualizarPessoa(pessoa);

                return Task.FromResult("Atualização realizada com sucesso");
            }
            catch (Exception ex)
            {
                return Task.FromResult(ex.Message);
            }
        }
    }
}
