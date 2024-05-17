using SQRSSample.Domain.ValueObjects;

namespace SQRSSample.Domain.Framework.Entity;
public abstract class Entity<TId> : IAuditableEntity
      where TId : struct,
      IComparable,
      IComparable<TId>,
      IConvertible,
      IEquatable<TId>,
      IFormattable
{
    public TId Id { get; protected set; }

    public BusinessId BusinessId { get; protected set; } = BusinessId.FromGuid(Guid.NewGuid());

    protected Entity() { }


    #region Equality Check
    public bool Equals(Entity<TId>? other) => this == other;
    public override bool Equals(object? obj) =>
         obj is Entity<TId> otherObject && Id.Equals(otherObject.Id);

    public override int GetHashCode() => Id.GetHashCode();
    public static bool operator ==(Entity<TId> left, Entity<TId> right)
    {
        if (left is null && right is null)
            return true;

        if (left is null || right is null)
            return false;

        return left.Equals(right);
    }

    public static bool operator !=(Entity<TId> left, Entity<TId> right)
        => !(right == left);

    #endregion
}


public abstract class Entity : Entity<long>
{

}
