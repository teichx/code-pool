namespace CodePool.Location.Models;


// [Index(nameof(Acronym), IsUnique = true)]
// [Index(nameof(StateId))]
public class Country
{
    public required int Id { get; set; }

    // [MaxLength(50)]
    // public string Name { get; set; }

    // [MaxLength(50)]
    // public string Slug { get; set; }

    // [MaxLength(50)]
    // public string Acronym { get; set; }


    // public required IEnumerable<State> States { get; set; }
}
