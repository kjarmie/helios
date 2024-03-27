using System.ComponentModel;
using System.Globalization;

namespace Common.Domain;

public class EntityIdTypeConverter<T> : TypeConverter where T : EntityId
{
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
        return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
    }

    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        var stringValue = value as string;
        if (!string.IsNullOrEmpty(stringValue) && Guid.TryParse(stringValue, out var guid))
        {
            return EntityId.Parse(guid);
        }

        return base.ConvertFrom(context, culture, value);
    }
}