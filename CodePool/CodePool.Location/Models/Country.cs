using System.ComponentModel.DataAnnotations;
using CodePool.Sharp.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace CodePool.Location.Models;

[Index(nameof(Slug), IsUnique = true)]
[Index(nameof(Acronym), IsUnique = true)]
public class Country : BaseModel
{
    [Key]
    public required int Id { get; set; }

    [Required, StringLength(50)]
    public required string Name { get; set; }

    [Required, StringLength(50)]
    public required string NativeName { get; set; }

    [Required, StringLength(50)]
    public required string Slug { get; set; }

    [Required, StringLength(2, MinimumLength = 2)]
    public required string Acronym { get; set; }

    public required IEnumerable<State> States { get; set; }
}
