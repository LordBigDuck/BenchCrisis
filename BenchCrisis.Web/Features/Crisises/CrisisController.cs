using BenchCrisis.Web.Features.Crisises.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchCrisis.Web.Features.Crisises
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrisisController : ControllerBase
    {
        public readonly IMediator _mediator;

        public CrisisController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        // TODO manage pagination
        public async Task<ActionResult<object>> GetAll()
        {
            var request = new GetAllCrisisRequest();
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetId([FromRoute] int id)
        {
            var request = new GetCrisisByIdRequest() { Id = id };
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<object>> Create([FromBody] CreateCrisisRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("{id}/teams")]
        public async Task<ActionResult<object>> Update([FromRoute] int id, ICollection<int> TeamIds)
        {
            var request = new UpdateCrisisTeamsRequest
            {
                CrisisId = id,
                TeamIds = TeamIds
            };

            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<object>> Update([FromRoute] int id, UpdateCrisisInformationRequest request)
        {
            if (id != request.CrisisId)
                return BadRequest("Endpoint entity Id does not match request entity id");

            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
