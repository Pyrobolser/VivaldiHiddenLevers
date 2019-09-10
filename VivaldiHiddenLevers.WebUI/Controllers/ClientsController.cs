using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Threading.Tasks;
using VivaldiHiddenLevers.Application.Clients.Commands;
using VivaldiHiddenLevers.Application.Clients.Queries.GetClientDetail;
using VivaldiHiddenLevers.Application.Clients.Queries.GetClientsList;
using VivaldiHiddenLevers.Application.Exceptions;

namespace VivaldiHiddenLevers.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [OpenApiTag("Clients", Description = "Clients related operations.")]
    public class ClientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ClientsListViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<ClientsListViewModel>> GetAll()
        {
            return Ok(await _mediator.Send(new GetClientsListQuery()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClientDetailModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundException), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClientDetailModel>> Get(int id)
        {
            return Ok(await _mediator.Send(new GetClientDetailQuery { Id = id }));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]CreateClientCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}