using MediatR;
using Microsoft.AspNetCore.Mvc;
using ECommerceDDD.Application.ReadModels;
using ECommerceDDD.Application.Queries.Cliente;


namespace ECommerceDDD.Services.Api.Controller
{
    [ApiController]
    [Route("api/clientes")]
    public class ClienteQueryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteQueryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteReadModel>>> GetAll()
        {
            var query = new GetAllClientesQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}