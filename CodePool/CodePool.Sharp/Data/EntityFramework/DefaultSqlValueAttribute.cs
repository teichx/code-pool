namespace CodePool.Sharp.Data.EntityFramework;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class DefaultSqlValueAttribute(string defaultSqlValue) : Attribute
{
    public string DefaultValueSql { get; private init; } = defaultSqlValue;

    public override string ToString()
        => DefaultValueSql;

    public override int GetHashCode()
        => DefaultValueSql.GetHashCode();
}
