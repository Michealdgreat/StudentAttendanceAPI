using MediatR;

namespace Common.Domain.Bases
{
    /// <summary>
    /// This is a marker for a Mediatr notification service. Handlers can publish this events to perform a task
    /// after a successful operation or failed operation.
    /// </summary>
    public class BaseDomainEvent : INotification
    {
        public DateTime CreationDate { get; protected set; }

        public BaseDomainEvent() { CreationDate = DateTime.Now; }
    }
}
