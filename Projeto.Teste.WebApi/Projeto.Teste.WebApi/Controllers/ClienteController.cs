using Microsoft.AspNetCore.Mvc;
using Projeto.Teste.Aplicacao.Handlers;
using Projeto.Teste.Dominio.Comandos;
using Projeto.Teste.Dominio.Comandos.Request;
using Projeto.Teste.Dominio.Comandos.Response;
using Projeto.Teste.Dominio.Consultas.Request;
using Projeto.Teste.Dominio.Consultas.Response;
using Projeto.Teste.Dominio.DTO;
using System.Net;

namespace Projeto.Teste.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private ICriarClienteHandler _clienteHandler;
        private IConsultaClienteHandler _consultaClienteHandler;
        private IAtualizarClienteHandler _atualizaClienteHandler;

        public ClienteController(
            ILogger<ClienteController> logger,
            ICriarClienteHandler clienteHandler,
            IConsultaClienteHandler consultaCategoriaHandler,
            IAtualizarClienteHandler atualizaClienteHandler)
        {
            _logger = logger;
            _clienteHandler = clienteHandler;
            _consultaClienteHandler = consultaCategoriaHandler;
            _atualizaClienteHandler = atualizaClienteHandler;
        }

        [HttpPost("CriarCliente")]
        [ProducesResponseType(typeof(Resultado<CriarClienteResponse>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(Resultado<string>), (int)HttpStatusCode.BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> CriarAsync(CriarClienteRequest command)
        {
            var resultado = await _clienteHandler.Handle(command);

            if (resultado.Sucesso)
                return Created("Cliente", resultado);

                return BadRequest(resultado);
        }


        [HttpPost("ObterCliente")]
        [ProducesResponseType(typeof(Resultado<ConsultarClienteResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(Resultado<string>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Resultado<string>), (int)HttpStatusCode.NotFound)]
        [Produces("application/json")]
        public async Task<IActionResult> ConsultarAsync(ConsultarClienteRequest query)
        {
            var resultado = await _consultaClienteHandler.Handle(query);

            if (resultado.Sucesso)
            {
                if (resultado?.Data?.Count() >= 1)
                    return Ok(resultado);
                else
                    return NotFound();
            }

            return BadRequest(resultado);
        }

        [HttpPut("AtualizaCliente")]
        [ProducesResponseType(typeof(Resultado<string>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(Resultado<string>), (int)HttpStatusCode.BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> AtualizaAsync(AtualizarClienteRequest command)
        {
            var resultado = await _atualizaClienteHandler.Handle(command);

            if (resultado.Sucesso)
                return Ok(resultado);

            return BadRequest(resultado);
        }
    }
}