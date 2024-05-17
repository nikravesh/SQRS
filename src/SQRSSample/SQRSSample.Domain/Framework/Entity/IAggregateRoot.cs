using SQRSSample.Domain.Framework.Events;

namespace SQRSSample.Domain.Framework.Entity;

public interface IAggregateRoot
{
    void ClearEvents();
    IEnumerable<IDomainEvent> GetEvents();
}
