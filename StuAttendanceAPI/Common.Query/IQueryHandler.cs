using MediatR;

namespace Common.Query
{
    /// <summary>
    /// Marker for all query request handler.
    /// </summary>
    /// <typeparam name="TQuery">The query</typeparam>
    /// <typeparam name="TResponse">Response type</typeparam>
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse> where TResponse : class?
    {

    }
}