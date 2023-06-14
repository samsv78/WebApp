using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Entities;


namespace WebApplication1.Models.Context;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DataContext()
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    public virtual DbSet<User> User { get; set; }
}