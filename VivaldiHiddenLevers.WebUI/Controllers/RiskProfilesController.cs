using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Threading.Tasks;
using VivaldiHiddenLevers.Application.Exceptions;
using VivaldiHiddenLevers.Application.RiskProfiles.Commands;
using VivaldiHiddenLevers.Application.RiskProfiles.Queries.GetRiskProfileForClient;

namespace VivaldiHiddenLevers.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [OpenApiTag("RiskProfiles", Description = "'HiddenLever - Risk Profile' related operations.")]
    public class RiskProfilesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RiskProfilesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{clientid}")]
        [ProducesResponseType(typeof(RiskProfileDetailModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundException), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RiskProfileDetailModel>> GetForClient(int clientid)
        {
            return Ok(await _mediator.Send(new GetRiskProfileDetailForClientQuery { ClientId = clientid }));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Create([FromBody]CreateRiskProfileForClient command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}