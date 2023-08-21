using CodePool.Location.Models;
using CodePool.Location.ValueObject.Pagination;

namespace CodePool.Location.Repository.Interfaces;

public interface ICountryRepository
{
    ValueTask<Country> GetById(int id);
    ValueTask<Country> GetByAcronym(string acronym);
    ValueTask<IEnumerable<Country>> ListCountries(Pagination pagination);
    ValueTask<IEnumerable<Country>> ListCountriesByName(string name, Pagination pagination);
}
