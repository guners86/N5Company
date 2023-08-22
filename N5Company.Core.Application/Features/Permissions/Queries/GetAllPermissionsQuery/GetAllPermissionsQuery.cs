using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using N5Company.Core.Application.DataTransferObjects;
using N5Company.Core.Application.Interfaces;
using N5Company.Core.Application.Wrappers;

namespace N5Company.Core.Application.Features.Permissions.Queries.GetAllPermissionsQuery
{
    public class GetAllPermissionsQuery : IRequest<ApiResponse<List<PermissionsDto>>>
    {
        public class GetAllPermissionsQueryHandler : IRequestHandler<GetAllPermissionsQuery, ApiResponse<List<PermissionsDto>>>
        {
            private readonly IRepositoryAsync<Domain.Entities.Permissions> _repositoryAsync;
            private readonly IMapper _mapper;
            private readonly ILogger<GetAllPermissionsQueryHandler> _logger;

            public GetAllPermissionsQueryHandler(IRepositoryAsync<Domain.Entities.Permissions> repositoryAsync, IMapper mapper, ILogger<GetAllPermissionsQueryHandler> logger)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<ApiResponse<List<PermissionsDto>>> Handle(GetAllPermissionsQuery request, CancellationToken cancellationToken)
            {
                _logger.LogInformation("Get All Permissions");
                var permissions = await _repositoryAsync.ListAsync();
                var response = _mapper.Map<List<PermissionsDto>>(permissions);
                return new ApiResponse<List<PermissionsDto>>(response);
            }
        }
    }
}
