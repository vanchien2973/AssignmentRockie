using ASP.NET_Core_API_Assignment_1.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_API_Assignment_1.Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
{
    public DbSet<TaskItem> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskItem>().HasKey(t => t.Id);
    }
}