using System.Globalization;

namespace CodePool.Sharp.ValueObject;

public readonly struct CustomerId
{
    public readonly int Id { get; }
    private CustomerId(int id)
        => Id = id;

    public override string ToString()
        => Id.ToString(CultureInfo.InvariantCulture);

    public override int GetHashCode() => Id.GetHashCode();

    public static implicit operator int(CustomerId customerId) => customerId.Id;
    public static implicit operator CustomerId(int id) => new(id);

    static readonly Lazy<CustomerId> _empty = new(() => new(0));
    public static CustomerId Empty => _empty.Value;
}
