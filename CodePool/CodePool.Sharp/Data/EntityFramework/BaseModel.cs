namespace CodePool.Sharp.Data.EntityFramework;

public class BaseModel
{
    [DefaultSqlValue("now()")]
    public DateTime CreatedAt { get; set; }

    [DefaultSqlValue("now()")]
    public DateTime UpdatedAt { get; set; }
}
