using System.ComponentModel.DataAnnotations;
using CodePool.Sharp.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace CodePool.Location.Models;

[Index(nameof(Slug), nameof(StateId), IsUnique = true)]
public class City : BaseModel
{
    [Key]
    public required int Id { get; set; }

    [Required, StringLength(50)]
    public required string Name { get; set; }

    [Required, StringLength(50)]
    public required string Slug { get; set; }
    public required int StateId { get; set; }

    public virtual State State { get; set; } = null!;
}
