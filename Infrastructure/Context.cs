using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
}
