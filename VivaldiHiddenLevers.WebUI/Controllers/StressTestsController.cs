using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Threading.Tasks;
using VivaldiHiddenLevers.Application.Exceptions;
using VivaldiHiddenLevers.Application.StressTests.Commands;
using VivaldiHiddenLevers.Application.StressTests.Queries.GetStressTestForClient;

namespace VivaldiHiddenLevers.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [OpenApiTag("StressTests", Description = "'HiddenLever - Stress Test' related operations.")]
    public class StressTestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StressTestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{clientid}")]
        [ProducesResponseType(typeof(StressTestDetailModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundException), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StressTestDetailModel>> GetForClient(int clientid)
        {
            return Ok(await _mediator.Send(new GetStressTestDetailForClientQuery { ClientId = clientid }));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Create([FromBody]CreateStressTestForClient command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}