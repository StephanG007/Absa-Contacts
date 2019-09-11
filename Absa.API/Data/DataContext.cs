using Absa.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Absa.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
        
        public DbSet<Value> Values { get; set; }
    }
}