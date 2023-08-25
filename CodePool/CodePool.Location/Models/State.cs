using System.ComponentModel.DataAnnotations;
using CodePool.Sharp.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace CodePool.Location.Models;

[Index(nameof(Acronym), nameof(CountryId), IsUnique = true)]
public class State : BaseModel
{
    [Key]
    public required int Id { get; set; }

    [Required, StringLength(50)]
    public required string Name { get; set; }

    [Required, StringLength(2)]
    public required string Acronym { get; set; }

    [Required]
    public required int CountryId { get; set; }

    public virtual Country Country { get; set; } = null!;
    public virtual ICollection<City> Cities { get; set; } = null!;
}
