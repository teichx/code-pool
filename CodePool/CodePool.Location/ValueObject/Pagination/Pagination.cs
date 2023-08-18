namespace CodePool.Location.ValueObject.Pagination;

public readonly struct Pagination
{
    internal readonly Page Page;
    internal readonly Limit Limit;
    internal readonly Offset Offset;

    private Pagination((Page page, Limit limit) tuple)
        => (Page, Limit, Offset) = (tuple.page, tuple.limit, tuple);

    public static implicit operator Pagination((Page page, Limit limit) tuple) => new(tuple);
}
