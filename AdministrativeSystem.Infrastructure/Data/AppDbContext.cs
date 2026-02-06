using AdministrativeSystem.Domain.Entities;
using AdministrativeSystem.Infrastructure.Data.Configurations;
using AdministrativeSystem.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Client = MySqlX.XDevAPI.Client;

namespace AdministrativeSystem.Infrastructure.Data;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Client> Clients { get; private set; }
    public DbSet<Product> Products { get; private set; }
    public DbSet<Order> Orders { get; private set; }
    public DbSet<OrderItem> OrderItems { get; private set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new ClientConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
    }
}