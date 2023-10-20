using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Crud.Application.AtualizarPessoa.Command
{
    public class AtualizaPessoaCommand : IRequest<string>
    {
        
        ///<example>1</example> 
        [JsonPropertyName("id")]
        [Required]
        public int Id { get; set; }

        ///<example>Bill Gates</example>
        [JsonPropertyName("nome")]
        [Required]
        public string Nome { get; set; }

        ///<example>999.999-999-99</example>
        [JsonPropertyName("cpf")]
        [Required]
        public string Cpf { get; set; }

        ///<example>seuemail@gmail.com</example>
        [JsonPropertyName("email")]
        [Required]
        public string Email { get; set; }

        ///<example>(99)9999-99999</example>
        [JsonPropertyName("telefone")]
        [Required]
        public string Telefone { get; set; }
    }
}
