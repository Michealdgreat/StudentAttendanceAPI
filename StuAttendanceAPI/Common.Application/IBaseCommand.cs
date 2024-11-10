using MediatR;

namespace Common.Application
{
    /// <summary>
    /// A base command interface that every Command must inherit from.
    /// </summary>
    public interface IBaseCommand : IRequest<OperationResult>
    {
    }

}