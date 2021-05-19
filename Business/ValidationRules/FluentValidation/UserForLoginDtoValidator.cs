using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserForLoginDtoValidator : AbstractValidator<UserForLoginDto>
    {
        public UserForLoginDtoValidator()
        {
            RuleFor(x => x.Email).NotNull();
            RuleFor(x => x.Email).MinimumLength(1);

            RuleFor(x => x.Password).NotNull();
            RuleFor(x => x.Password).MinimumLength(1);
        }
    }
}