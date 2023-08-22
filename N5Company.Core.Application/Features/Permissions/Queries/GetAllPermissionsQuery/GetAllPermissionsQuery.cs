using AutoMapper;
using MediatR;
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

            public GetAllPermissionsQueryHandler(IRepositoryAsync<Domain.Entities.Permissions> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<ApiResponse<List<PermissionsDto>>> Handle(GetAllPermissionsQuery request, CancellationToken cancellationToken)
            {
                var permissions = await _repositoryAsync.ListAsync();
                var response = _mapper.Map<List<PermissionsDto>>(permissions);
                return new ApiResponse<List<PermissionsDto>>(response);
            }
        }
    }
}
