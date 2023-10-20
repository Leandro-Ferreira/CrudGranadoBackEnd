using MediatR;

namespace Crud.Application.ExcluirPessoa.Command
{
    /// <summary>
    /// 
    /// </summary>
    public  class ExcluiPessoaCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
