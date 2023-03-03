using DevJJGR.Domain.Entities;
using DevJJGR.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DevJJGR.Persistence;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }
    public DbSet<Categories> Categories { get; set; }
    public DbSet<Products> Products { get; set; }
    //protected override void OnModelCreating(ModelBuilder modelBuilder) =>
    //    modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Categories>().HasKey(X => X.CategoryId);
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new CategoriesConfiguration());
        builder.ApplyConfiguration(new ProductsConfiguration());

    }
}
