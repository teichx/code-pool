using System.Globalization;

namespace CodePool.Sharp.ValueObject.Pagination;

public readonly struct Page
{
    private readonly int _pageNumber;
    private Page(int pageNumber)
        => _pageNumber = Math.Max(pageNumber, 1);

    public override string ToString()
        => _pageNumber.ToString(CultureInfo.InvariantCulture);

    public override int GetHashCode() => _pageNumber.GetHashCode();

    public static implicit operator int(Page page) => page._pageNumber;
    public static implicit operator Page(int pageNumber) => new(pageNumber);
}
