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


    /// <summary>
    /// Command handlker that porovide a response should inherit from this interface.
    /// </summary>
    /// <typeparam name="TCommand">Command</typeparam>
    /// <typeparam name="TResponseData">Response</typeparam>
    public interface IBaseCommandHandler<TCommand, TResponseData> : IRequestHandler<TCommand, OperationResult<TResponseData>> where TCommand : IBaseCommand<TResponseData>
    {
    }
}