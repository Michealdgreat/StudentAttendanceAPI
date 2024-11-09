using MediatR;

namespace Common.Application
{
    /// <summary>
    /// A base command interface that every Command must inherit from.
    /// </summary>
    public interface IBaseCommand : IRequest<OperationResult>
    {
    }

    /// <summary>
    /// Every command that provide a response should inherit from this interface, where TData is the Response
    /// </summary>
    /// <typeparam name="TData"> Response. Constraint is a Class</typeparam>
    public interface IBaseCommand<TData> : IRequest<OperationResult<TData>>
    {
    }
}