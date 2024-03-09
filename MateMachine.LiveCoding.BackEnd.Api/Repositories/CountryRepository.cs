using MateMachine.LiveCoding.BackEnd.Api.DataAccess;
using MateMachine.LiveCoding.BackEnd.Api.Domain;

namespace MateMachine.LiveCoding.BackEnd.Api.Repositories;

public interface ICountryRepository
{
    Task<Country> Get(int id);
    Task<int> Add(Country country);
    Task Update(Country country);
    Task Delete(int id);
}

public class CountryRepository(AppDbContext context) : ICountryRepository
{
    private readonly AppDbContext _context = context;

    public async Task<int> Add(Country country)
    {
        _context.Countries.Add(country);
        await _context.SaveChangesAsync();
        return country.Id;
    }

    public async Task Delete(int id)
    {
        var country = await _context.Countries.FindAsync(id);
        if (country != null)
        {
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Country> Get(int id)
    {
        return await _context.Countries.FindAsync(id);
    }

    public async Task Update(Country country)
    {
        _context.Countries.Update(country);
        await _context.SaveChangesAsync();
    }
}
