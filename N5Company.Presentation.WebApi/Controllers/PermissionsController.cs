using Microsoft.AspNetCore.Mvc;
using N5Company.Core.Application.Features.Permissions.Commands.CreatePermissionsCommand;
using N5Company.Core.Application.Features.Permissions.Commands.UpdatePermissionsCommand;
using N5Company.Core.Application.Features.Permissions.Queries.GetAllPermissionsQuery;
using N5Company.Core.Application.Wrappers;
using System.Net;

namespace N5Company.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : BaseApiController
    {

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var response = await Mediator.Send(new GetAllPermissionsQuery());
            return Ok(response);
        }

        [HttpGet("{id:int}", Name = "GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await Mediator.Send(new GetPermissionsByIdQuery { Id = id });
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(CreatePermissionCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, UpdatePermissionsCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            var response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}
