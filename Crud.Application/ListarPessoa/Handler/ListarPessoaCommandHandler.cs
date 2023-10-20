using Crud.Application.ListarPessoa.Command;
using Crud.Application.ListarPessoa.Response;
using Crud.Core.Repository;
using MediatR;

namespace Crud.Application.ListarPessoa.Handler
{
    public class ListarPessoaCommandHandler : IRequestHandler<ListaPessoaCommand, IReadOnlyCollection<PessoaResponse>>
    {
        private readonly IPessoaRepository _repository;

        public ListarPessoaCommandHandler(IPessoaRepository repository)
        {
            _repository = repository;            
        }

        public async Task<IReadOnlyCollection<PessoaResponse>> Handle(ListaPessoaCommand request, CancellationToken cancellationToken)
        {
            var response = _repository.ListarTodos();

            var listaPessoaResponse = response.Select(pessoa => new PessoaResponse
            {
                Id       = pessoa.Id,
                Nome     = pessoa.Nome,
                Cpf      = pessoa.Cpf,
                Telefone = pessoa.Telefone,
                Email    = pessoa.Email
            
            }).ToList();

            return await Task.FromResult(listaPessoaResponse);
        }
    }
}
