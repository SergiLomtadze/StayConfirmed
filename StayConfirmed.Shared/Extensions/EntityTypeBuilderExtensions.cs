using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StayConfirmed.Shared.Comparers;
using StayConfirmed.Shared.Converters;

namespace StayConfirmed.Shared.Extensions;

public static class EntityTypeBuilderExtensions
{
    public static PropertyBuilder<T> HasJsonConversion<T>(this PropertyBuilder<T> builder)
        where T : class
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));

        builder.HasConversion(new ValueObjectToJsonConverter<T>());

        return builder;
    }

    public static PropertyBuilder<T> HasEnumToStringConversion<T>(this PropertyBuilder<T> builder)
        where T : struct, Enum
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));

        builder.HasConversion(new EnumToStringConverter<T>());

        return builder;
    }

    public static PropertyBuilder<T> HasJsonToCollectionComparer<T>(this PropertyBuilder<T> builder)
    where T : class
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder
            .Metadata
            .SetValueComparer(new JsonDataToCollectionValueComparer<T>());

        return builder;
    }
}
