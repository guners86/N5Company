using AutoMapper;
using MediatR;
using N5Company.Core.Application.Interfaces;
using N5Company.Core.Application.Wrappers;
using N5Company.Core.Domain.Entities;
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
        public int PermissionTypeId { get; set; }
    }

    public class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand, ApiResponse<int>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Permissions> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreatePermissionCommandHandler(IRepositoryAsync<Domain.Entities.Permissions> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<ApiResponse<int>> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
        {
            var newRecord = _mapper.Map<Domain.Entities.Permissions>(request);
            var data = await _repositoryAsync.AddAsync(newRecord);
            return new ApiResponse<int>(data.Id);
        }
    } 
}
