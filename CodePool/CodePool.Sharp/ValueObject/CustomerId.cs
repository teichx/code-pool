using System.Globalization;
using System.Text.Json.Serialization;
using CodePool.Sharp.Serializer;
using CodePool.Sharp.Serializer.Interfaces;

namespace CodePool.Sharp.ValueObject;

[JsonConverter(typeof(SerializeToInt.IntJsonConverter))]
public readonly struct CustomerId : IConvertibleToInt
{
    public readonly int Id { get; }
    private CustomerId(int id)
        => Id = id;

    public override string ToString()
        => Id.ToString(CultureInfo.InvariantCulture);

    public override int GetHashCode() => Id.GetHashCode();
    public int ToInt() => Id;

    public static implicit operator int(CustomerId customerId) => customerId.Id;
    public static implicit operator CustomerId(int id) => new(id);

    static readonly Lazy<CustomerId> _empty = new(() => new(0));
    public static CustomerId Empty => _empty.Value;
}

[JsonSourceGenerationOptions]
[JsonSerializable(typeof(CustomerId))]
sealed partial class CustomerIdContext : JsonSerializerContext
{
}
