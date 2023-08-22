using Microsoft.AspNetCore.Mvc;
using N5Company.Core.Application.Features.Permissions.Commands.CreatePermissionsCommand;
using N5Company.Core.Application.Wrappers;

namespace N5Company.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : BaseApiController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(CreatePermissionCommand command)
        {
            var response = await Mediator.Send(command);
            //return CreatedAtRoute("GetVilla", new { id = response }, response);
            return Ok(response);
        }


    }
}
