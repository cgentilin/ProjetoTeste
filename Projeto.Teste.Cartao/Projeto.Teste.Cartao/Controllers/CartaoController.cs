using MediatR;
using Microsoft.AspNetCore.Mvc;
using Projeto.Teste.Cartao.Dominio.Consultas;
using Projeto.Teste.Cartao.Dominio.DTO;
using System.Net;

namespace Projeto.Teste.Cartao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartaoController : ControllerBase
    {
        
        private readonly ILogger<CartaoController> _logger;
        private readonly IMediator _mediator;

        public CartaoController(ILogger<CartaoController> logger, [FromServices]IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("consultar")]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ConsultarCartao([FromQuery] ConsultarCartaoComando command)
        {
            var response = await _mediator.Send(command).ConfigureAwait(false);
            
            if (response.Errors.Any())
                return BadRequest(response.Errors);

            return Ok(response.Result);
        }


    }
}