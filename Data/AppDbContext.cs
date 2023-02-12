using DrabLibrary.Model;
using Microsoft.EntityFrameworkCore;

namespace DrabLibrary.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Book> Books { get; set; }
}
