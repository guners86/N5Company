using MediatR;
using N5Company.Core.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5Company.Core.Application.Features.Permissions.Commands.CreatePermissionsCommand
{
    public class CreatePermissionCommand : IRequest<ApiResponse<int>>
    {
        public string EmployeName { get; set; } = string.Empty;
        public string EmpolyeLastname { get; set; } = string.Empty;
        public DateTime PermissionDate { get; set; }
    }

    public class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand, ApiResponse<int>>
    {
        public Task<ApiResponse<int>> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    } 
}
