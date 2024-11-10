using MediatR;

namespace Common.Application
{
    /// <summary>
    /// All command handler should inherit from this Interface.
    /// </summary>
    /// <typeparam name="TCommand">TCommand is a constraint on all command required</typeparam>
    public interface IBaseCommandHandler<TCommand> : IRequestHandler<TCommand, OperationResult> where TCommand : IBaseCommand
    {
    }

}