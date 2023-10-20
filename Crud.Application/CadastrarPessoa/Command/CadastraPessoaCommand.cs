using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Crud.Application.CadastrarPessoa.Command
{
    /// <summary>
    /// DTO para cadastro de pessoa
    /// </summary>
    public class CadastraPessoaCommand : IRequest<string>
    {
        ///<example>Steve Jobs</example>
        [Required]
        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        ///<example>999.999.999-99</example>
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

