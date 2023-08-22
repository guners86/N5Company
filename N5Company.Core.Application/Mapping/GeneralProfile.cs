using AutoMapper;
using N5Company.Core.Application.DataTransferObjects;
using N5Company.Core.Application.Features.Permissions.Commands.CreatePermissionsCommand;
using N5Company.Core.Domain.Entities;

namespace N5Company.Core.Application.Mapping
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region DataTransferObjects
            CreateMap<Permissions, PermissionsDto>();
            #endregion

            #region Commands
            CreateMap<CreatePermissionCommand, Permissions>();
            #endregion
        }
    }
}
