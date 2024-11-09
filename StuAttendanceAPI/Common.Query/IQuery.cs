using MediatR;

namespace Common.Query
{
    /// <summary>
    /// Marker for all query request.
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public interface IQuery<TResponse> : IRequest<TResponse> where TResponse : class?
    {

    }
}