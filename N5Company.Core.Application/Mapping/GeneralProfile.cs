using AutoMapper;
using N5Company.Core.Application.Features.Permissions.Commands.CreatePermissionsCommand;
using N5Company.Core.Domain.Entities;

namespace N5Company.Core.Application.Mapping
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region Commands
            CreateMap<CreatePermissionCommand, Permissions>();
            #endregion
        }
    }
}
