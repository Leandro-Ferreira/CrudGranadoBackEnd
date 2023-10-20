using Crud.Application.AtualizarPessoa.Command;
using Crud.Application.CadastrarPessoa.Command;
using Crud.Application.ExcluirPessoa.Command;
using Crud.Application.ListarPessoa.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Crud.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public PessoaController(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        /// Cadastra uma pessoa
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Uma mensagem informando se o cadastro teve sucesso ou não</returns>
        [HttpPost]
        [Route("cadastrarPessoa")]
        public async Task<IActionResult> CadastrarPessoa([FromBody] CadastraPessoaCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

               return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


       /// <summary>
       /// Retorna todas as pessoas que estão cadastradas
       /// </summary>
       /// <returns>Uma lista de pessoas</returns>
        [HttpGet]
        [Route("listarTodasAsPessoas")]
        public async Task<IActionResult> ListarTodasAsPessoas()
        {
            try
            {
                var command = new ListaPessoaCommand();

                var result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Atualizar o cadastro 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("atualizarPessoa")]
        public async Task<IActionResult> AtualizarPessoa([FromBody] AtualizaPessoaCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

                return Ok(result);
            }
            
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);  
            }
        }

        /// <summary>
        ///  Exclui a pessoa com base no id
        /// </summary>
        /// <param name="id">1</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("excluirPessoa")]
        public async Task<IActionResult> ExcluirPessoa(int id)
        {
            try
            {
                var command = new ExcluiPessoaCommand
                {
                    Id = id
                };

                var result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex) 
            { 
               return BadRequest(ex.Message);
            }
        }
    }
}
