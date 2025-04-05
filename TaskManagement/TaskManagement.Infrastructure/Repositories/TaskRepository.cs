using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Data;

namespace TaskManagement.Infrastructure.Repositories;

public class TaskRepository(ApplicationDbContext context) : ITaskRepository
{
    public async Task<Task> AddAsync(Task task)
    {
        await context.Tasks.AddAsync(task);
        await context.SaveChangesAsync();
        return task;
    }

    public async Task BulkAddAsync(IEnumerable<Task> tasks)
    {
        await context.Tasks.AddRangeAsync(tasks);
        await context.SaveChangesAsync();
    }

    public async Task BulkDeleteAsync(IEnumerable<Guid> taskIds)
    {
        var tasksToDelete = await context.Tasks
            .Where(t => taskIds.Contains(t.Id))
            .ToListAsync();
        context.Tasks.RemoveRange(tasksToDelete);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Task task)
    {
        context.Tasks.Remove(task);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Task>> GetAllAsync()
    {
        return await context.Tasks.ToListAsync();
    }

    public async Task<Task> GetByIdAsync(Guid id)
    {
        return await context.Tasks.FindAsync(id);
    }

    public async Task UpdateAsync(Task task)
    {
        task.UpdatedAt = DateTime.UtcNow;
        context.Tasks.Update(task);
        await context.SaveChangesAsync();
    }
}