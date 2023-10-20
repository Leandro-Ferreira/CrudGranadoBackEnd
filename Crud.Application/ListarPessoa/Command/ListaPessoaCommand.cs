using Crud.Application.ListarPessoa.Response;
using MediatR;

namespace Crud.Application.ListarPessoa.Command
{
    public class ListaPessoaCommand : IRequest<IReadOnlyCollection<PessoaResponse>>
    {

    }
}
