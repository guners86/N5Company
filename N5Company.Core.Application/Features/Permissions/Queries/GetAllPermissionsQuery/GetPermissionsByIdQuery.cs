using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using N5Company.Core.Application.DataTransferObjects;
using N5Company.Core.Application.Interfaces;
using N5Company.Core.Application.Wrappers;

namespace N5Company.Core.Application.Features.Permissions.Queries.GetAllPermissionsQuery
{
    public class GetPermissionsByIdQuery : IRequest<ApiResponse<PermissionsDto>>
    {
        public int Id { get; set; }

        public class GetPermissionsByIdQueryHandler : IRequestHandler<GetPermissionsByIdQuery, ApiResponse<PermissionsDto>>
        {
            private readonly IRepositoryAsync<Domain.Entities.Permissions> _repositoryAsync;
            private readonly IMapper _mapper;
            private readonly ILogger<GetPermissionsByIdQueryHandler> _logger;

            public GetPermissionsByIdQueryHandler(IRepositoryAsync<Domain.Entities.Permissions> repositoryAsync, IMapper mapper, ILogger<GetPermissionsByIdQueryHandler> logger)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<ApiResponse<PermissionsDto>> Handle(GetPermissionsByIdQuery request, CancellationToken cancellationToken)
            {
                _logger.LogInformation($"Get Permissions by Id: {request.Id}");
                var permission = await _repositoryAsync.GetByIdAsync(request.Id);

                if (permission == null) 
                {
                    string message = $"Error to get Permissions by Id: {request.Id}";
                    _logger.LogError(message);
                    throw new KeyNotFoundException(message);
                }

                var response = _mapper.Map<PermissionsDto>(permission);
                return new ApiResponse<PermissionsDto>(response);
            }
        }
    }
}
