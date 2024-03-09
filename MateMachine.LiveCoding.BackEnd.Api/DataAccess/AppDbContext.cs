using MateMachine.LiveCoding.BackEnd.Api.Domain;

using Microsoft.EntityFrameworkCore;

namespace MateMachine.LiveCoding.BackEnd.Api.DataAccess;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Country> Countries { get; set; }
}
