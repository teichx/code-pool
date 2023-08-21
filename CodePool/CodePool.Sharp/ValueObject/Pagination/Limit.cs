using System.Globalization;

namespace CodePool.Sharp.ValueObject.Pagination;

public readonly struct Limit
{
    private readonly int _limit;
    private Limit(int limit)
        => _limit = limit;
    private Limit((int limit, int maxLimit) tuple)
        => _limit = Math.Max(tuple.limit, tuple.maxLimit);

    public override string ToString()
        => _limit.ToString(CultureInfo.InvariantCulture);

    public override int GetHashCode() => _limit.GetHashCode();

    public static implicit operator int(Limit limit) => limit._limit;
    public static implicit operator Limit(int limit) => new(limit);
    public static implicit operator Limit((int limit, int maxLimit) tuple) => new(tuple);
}
