namespace Common.Domain;

public record EntityId : IComparable<EntityId>
{
    public Guid Value { get; }

    public EntityId(Guid value)
    {
        Value = value;
    }

    public static EntityId New()
    {
        return new EntityId(Guid.NewGuid());
    }

    public int CompareTo(EntityId? other)
    {
        return Value.CompareTo(other.Value);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}