using Microsoft.EntityFrameworkCore;
using EFCoreDemo.Models;

namespace EFCoreDemo.Data;

public class AppDbContext : DbContext
{
    public DbSet<InventoryItem> InventoryItems => Set<InventoryItem>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EFCoreInventoryDemo;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
