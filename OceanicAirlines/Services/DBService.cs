using Microsoft.EntityFrameworkCore;
using OceanicAirlines.Models;

namespace OceanicAirlines.Services
{
    public class DBService : DbContext
    {
        public DBService(DbContextOptions<DBService> options)
    : base(options)
        {
        }

        public DbSet<City> CityItems { get; set; } = null!;
    }
}
