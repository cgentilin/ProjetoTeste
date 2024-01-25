using MediatR;
using Microsoft.AspNetCore.Mvc;
using Projeto.Teste.Cartao.Dominio.Comandos;
using Projeto.Teste.Cartao.Dominio.Consultas;
using Projeto.Teste.Cartao.Dominio.DTO;
using System.Net;

namespace Projeto.Teste.Cartao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropostaController : ControllerBase
    {
        
        private readonly ILogger<PropostaController> _logger;
        private readonly IMediator _mediator;

        public PropostaController(ILogger<PropostaController> logger, [FromServices]IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("Inserir")]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> InserirProposta([FromBody] InserirPropostaComando command)
        {
            var response = await _mediator.Send(command).ConfigureAwait(false);

            if (response.Errors.Any())
                return BadRequest(response.Errors);

            return Ok(response.Result);
        }

        [HttpGet("consultar")]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ConsultarProposta([FromQuery] ConsultarPropostaComando command)
        {
            var response = await _mediator.Send(command).ConfigureAwait(false);
            
            if (response.Errors.Any())
                return BadRequest(response.Errors);

            return Ok(response.Result);
        }


    }
}