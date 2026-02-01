using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ECommerceDDD.Application.Command;
using ECommerceDDD.Application.DTOs;
using MediatR;


namespace ECommerceDDD.Services.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/cliente
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteCreateDto dto)
        {
            var command = new RegisterNewClienteCommand(
                dto.Nome,
                dto.Email,
                dto.DataNascimento
            );

            var result = await _mediator.Send(command);

            if (!result)
                return BadRequest("Erro ao cadastrar cliente.");

            return Ok("Cliente cadastrado com sucesso.");
        }

        // PUT: api/cliente
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ClienteUpdateDto dto)
        {
            var command = new UpdateClienteCommand(
                dto.Id,
                dto.Nome,
                dto.Email,
                dto.DataNascimento
            );

            var result = await _mediator.Send(command);

            if (!result)
                return NotFound("Cliente não encontrado.");

            return Ok("Cliente atualizado com sucesso.");
        }

        // DELETE: api/cliente/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new RemoveClienteCommand(id);

            var result = await _mediator.Send(command);

            if (!result)
                return NotFound("Cliente não encontrado.");

            return Ok("Cliente removido com sucesso.");
        }
    }
}

