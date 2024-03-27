using System.ComponentModel;

namespace Common.Domain;

[TypeConverter(typeof(EntityIdTypeConverter<EntityId>))]
public record EntityId : IComparable<EntityId>
{
    public Guid Value { get; }

    public EntityId(Guid value)
    {
        Value = value;
    }

    public static EntityId New() => new(Guid.NewGuid());

    public static EntityId Parse(Guid guid) => new(guid);

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