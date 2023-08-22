using MediatR;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> Post(CreatePermissionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


    }
}
