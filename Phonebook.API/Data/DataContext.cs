using Phonebook.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Phonebook.API.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Contact> Contacts { get; set; }
  }
}