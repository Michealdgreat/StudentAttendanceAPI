using FluentValidation;
using MediatR;
using System.Text;

namespace Common.Application.Validation
{
    /// <summary>
    /// Mediator pipeline that handles every command parameters validation.
    /// </summary>
    /// <typeparam name="TRequest">Command validator</typeparam>
    /// <typeparam name="TResponse">Command Validator response</typeparam>
    public class CommandValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public CommandValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var errors = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (errors.Any())
            {
                var errorBuilder = new StringBuilder();

                foreach (var error in errors)
                {
                    errorBuilder.AppendLine(error.ErrorMessage);
                }

                throw new InvalidCommandException(errorBuilder.ToString());
            }
            var response = await next();
            return response;
        }
    }
}