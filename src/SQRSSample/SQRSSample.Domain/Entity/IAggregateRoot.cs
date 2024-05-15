using SQRSSample.Domain.Events;

namespace SQRSSample.Domain.Entity;

public interface IAggregateRoot
{
    void ClearEvents();
    IEnumerable<IDomainEvent> GetEvents();
}
