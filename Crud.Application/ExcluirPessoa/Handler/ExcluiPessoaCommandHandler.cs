using Crud.Application.ExcluirPessoa.Command;
using Crud.Core.Repository;
using MediatR;

namespace Crud.Application.ExcluirPessoa.Handler
{
    public class ExcluiPessoaCommandHandler : IRequestHandler<ExcluiPessoaCommand,string>
    {

        private readonly IPessoaRepository _repository;


        public ExcluiPessoaCommandHandler(IPessoaRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(ExcluiPessoaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _repository.ExcluirPessoa(request.Id);

                return await Task.FromResult("Exclusão realizada com sucesso");
            }
            catch (Exception ex) 
            {
                return await Task.FromResult(ex.Message);
            }
        }
    }
}
