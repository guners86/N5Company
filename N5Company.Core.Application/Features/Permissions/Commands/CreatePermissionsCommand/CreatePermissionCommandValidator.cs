using FluentValidation;

namespace N5Company.Core.Application.Features.Permissions.Commands.CreatePermissionsCommand
{
    public class CreatePermissionCommandValidator : AbstractValidator<CreatePermissionCommand>
    {
        public CreatePermissionCommandValidator()
        {
            RuleFor(r => r.EmployeName)
                .NotEmpty().WithMessage("The field {PropertyName} is mandatory");

            RuleFor(r => r.EmpolyeLastname)
                .NotEmpty().WithMessage("The field {PropertyName} is mandatory");

            RuleFor(r => r.PermissionTypeId)
                .NotNull().WithMessage("The field {PropertyName} is mandatory")
                .Equal(0).WithMessage("The field {PropertyName} must be greater than zero");

            RuleFor(r => r.PermissionDate)
               .NotNull().WithMessage("The field {PropertyName} is mandatory");
        }
    }
}
