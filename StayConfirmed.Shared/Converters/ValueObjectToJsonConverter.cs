using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;
using System.Text.Json;

namespace StayConfirmed.Shared.Converters;

internal sealed class ValueObjectToJsonConverter<TObject> : ValueConverter<TObject, string>
    where TObject : class
{
    public ValueObjectToJsonConverter(ConverterMappingHints mappingHints = null)
        : base(ToJsonString, ToObjectT, mappingHints) { }

    #region PRIVATE MEMBERS

    private static Expression<Func<TObject, string>> ToJsonString => x => ToJsonSerialize(x);

    private static Expression<Func<string, TObject>> ToObjectT => x => FromJsonDeserialize(x);

    private static string ToJsonSerialize(TObject value) => JsonSerializer.Serialize(value);

    private static TObject FromJsonDeserialize(string jsonString) => JsonSerializer.Deserialize<TObject>(jsonString);

    #endregion
}
