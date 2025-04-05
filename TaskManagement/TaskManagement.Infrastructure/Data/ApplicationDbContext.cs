using Microsoft.EntityFrameworkCore;

namespace TaskManagement.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Task> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Task>().Property(t => t.Id).ValueGeneratedOnAdd();
        base.OnModelCreating(modelBuilder);
    }
}