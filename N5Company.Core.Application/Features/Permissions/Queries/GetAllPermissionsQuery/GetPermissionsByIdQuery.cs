using AutoMapper;
using MediatR;
using N5Company.Core.Application.DataTransferObjects;
using N5Company.Core.Application.Interfaces;
using N5Company.Core.Application.Wrappers;

namespace N5Company.Core.Application.Features.Permissions.Queries.GetAllPermissionsQuery
{
    public class GetPermissionsByIdQuery : IRequest<ApiResponse<PermissionsDto>>
    {
        public int Id { get; set; }

        public class GetAllPermissionsQueryHandler : IRequestHandler<GetPermissionsByIdQuery, ApiResponse<PermissionsDto>>
        {
            private readonly IRepositoryAsync<Domain.Entities.Permissions> _repositoryAsync;
            private readonly IMapper _mapper;

            public GetAllPermissionsQueryHandler(IRepositoryAsync<Domain.Entities.Permissions> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<ApiResponse<PermissionsDto>> Handle(GetPermissionsByIdQuery request, CancellationToken cancellationToken)
            {
                var permission = await _repositoryAsync.GetByIdAsync(request.Id);

                if (permission == null) 
                {
                    throw new KeyNotFoundException($"Record doest'n found with the id: {request.Id}");
                }

                var response = _mapper.Map<PermissionsDto>(permission);
                return new ApiResponse<PermissionsDto>(response);
            }
        }
    }
}
