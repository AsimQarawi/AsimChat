using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }
    // DataUser is the name of the table
    //<User> to defin the table coulomns and more
    public DbSet<User> DataUsers { get; set; }
}
