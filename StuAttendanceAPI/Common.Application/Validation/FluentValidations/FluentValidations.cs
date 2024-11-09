using FluentValidation;

namespace Common.Application.Validation.FluentValidations
{
    /// <summary>
    /// USED IN MEDIATOR PIPELINE
    /// Fluent validation for command request parameters
    /// </summary>
    public static class FluentValidations
    {
        public static IRuleBuilderOptionsConditions<T, string> ValidPhoneNumber<T>(this IRuleBuilder<T, string> ruleBuilder, string errorMessage = ValidationMessages.InvalidPhoneNumber)
        {
            return ruleBuilder.Custom((phoneNumber, context) =>
            {
                if (string.IsNullOrWhiteSpace(phoneNumber) || phoneNumber.Length is < 11 or > 11)
                    context.AddFailure(errorMessage);

            });
        }
    }
}