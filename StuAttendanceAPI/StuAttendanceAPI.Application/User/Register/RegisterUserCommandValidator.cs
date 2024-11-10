using Application.User.Register;
using Common.Application.Validation;
using FluentValidation;

namespace StuAttendanceAPI.Application.User.Register
{
    /// <summary>
    /// Validator for createUserCommand parameters.
    /// </summary>
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(r => r.Email).EmailAddress().Empty().WithMessage("Email address not valid");
            RuleFor(r => r.FirstName).EmailAddress().Empty().WithMessage("FirstName Required");
            RuleFor(r => r.LastName).EmailAddress().Empty().WithMessage("LastName Required");
            RuleFor(r => r.TagId).EmailAddress().Empty().WithMessage("TagId Field cannot be null");
        }
    }
}