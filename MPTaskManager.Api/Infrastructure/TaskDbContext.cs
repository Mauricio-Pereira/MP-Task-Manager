using Microsoft.EntityFrameworkCore;
using MPTaskManager.Api.Models;

namespace MPTaskManager.Api.Infrastructure;

public class TaskDbContext : DbContext
{
    
    public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
    {
    }

    public DbSet<TaskItem> TasksItems { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskItem>()
            .HasIndex(t => t.Id)
            .IsUnique();
    }
    
}