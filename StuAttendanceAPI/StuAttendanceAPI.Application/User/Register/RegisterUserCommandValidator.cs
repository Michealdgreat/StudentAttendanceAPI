using Common.Application.Validation;
using FluentValidation;

namespace Application.User.Register
{
    /// <summary>
    /// Validator for createUserCommand parameters.
    /// </summary>
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(r => r.Email).EmailAddress().WithMessage("Email address not valid");

            RuleFor(f => f.Password).NotEmpty().WithMessage(ValidationMessages.required("Required"))
                .NotNull().WithMessage(ValidationMessages.required("Password field cannot be null"))
                .MinimumLength(4).WithMessage(ValidationMessages.minLength("Password minimum length is ", 4));
        }
    }
}