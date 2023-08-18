namespace CodePool.Location.ValueObject.Pagination;

public readonly struct Offset
{
    private readonly int _offset;
    private Offset((Page page, Limit limit) tuple)
        => _offset = tuple.limit * (tuple.page - 1);

    public override string ToString()
        => _offset.ToString();

    public override int GetHashCode() => _offset.GetHashCode();

    public static implicit operator int(Offset limit) => limit._offset;
    public static implicit operator Offset((Page page, Limit limit) tuple) => new(tuple);
}
