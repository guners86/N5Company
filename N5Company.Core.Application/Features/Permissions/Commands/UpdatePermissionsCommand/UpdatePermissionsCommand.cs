using AutoMapper;
using MediatR;
using N5Company.Core.Application.Interfaces;
using N5Company.Core.Application.Wrappers;

namespace N5Company.Core.Application.Features.Permissions.Commands.UpdatePermissionsCommand
{
    public class UpdatePermissionsCommand : IRequest<ApiResponse<int>>
    {
        public int Id { get; set; }
        public string EmployeName { get; set; } = string.Empty;
        public string EmpolyeLastname { get; set; } = string.Empty;
        public DateTime PermissionDate { get; set; }
        public int PermissionTypeId { get; set; }
    }

    public class UpdatePermissionsCommandHandler : IRequestHandler<UpdatePermissionsCommand, ApiResponse<int>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Permissions> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdatePermissionsCommandHandler(IRepositoryAsync<Domain.Entities.Permissions> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<ApiResponse<int>> Handle(UpdatePermissionsCommand request, CancellationToken cancellationToken)
        {
            var record = await _repositoryAsync.GetByIdAsync(request.Id);
            
            if (record == null) 
            {
                throw new KeyNotFoundException($"Record doest'n found with the id: {request.Id}");
            }

            record.PermissionDate = request.PermissionDate;
            record.PermissionTypeId = request.PermissionTypeId;
            record.EmployeName = request.EmployeName;
            record.PermissionDate = request.PermissionDate;
            record.EmpolyeLastname = request.EmpolyeLastname;

            await _repositoryAsync.UpdateAsync(record);
            return new ApiResponse<int>(record.Id);
        }
    }
}
