using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserForRegisterDtoValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserForRegisterDtoValidator()
        {
            RuleFor(x => x.Email).NotNull();
            RuleFor(x => x.Email).MinimumLength(1);

            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.FirstName).MinimumLength(1);

            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.LastName).MinimumLength(1);

            RuleFor(x => x.Password).NotNull();
            RuleFor(x => x.Password).MinimumLength(1);
        }
    }
}