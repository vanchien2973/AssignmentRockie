using System.Text.RegularExpressions;
using ASP.NET_Core_API_Assignment_1.Domain.Entities;
using ASP.NET_Core_API_Assignment_1.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_API_Assignment_1.Infrastructure.Persistence.Repositories
{
    public class TaskRepository(ApplicationDbContext context) : ITaskRepository
    {
        public async Task<TaskItem?> GetByIdAsync(Guid id)
        {
            return await context.Tasks.FindAsync(id);
        }

        public async Task<IEnumerable<TaskItem?>> GetAllAsync()
        {
            return await context.Tasks.ToListAsync();
        }

        public async Task AddAsync(TaskItem? task)
        {
            await context.Tasks.AddAsync(task);
            await context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<TaskItem?> tasks)
        {
            await context.Tasks.AddRangeAsync(tasks);
            await context.SaveChangesAsync();
        }

        public void Update(TaskItem? task)
        {
            task.UpdatedAt = DateTime.UtcNow;
            context.Tasks.Update(task);
            context.SaveChanges();
        }

        public void Delete(TaskItem? task)
        {
            context.Tasks.Remove(task);
            context.SaveChanges();
        }

        public async Task DeleteRangeAsync(IEnumerable<Guid> taskIds)
        {
            var tasksToDelete = await context.Tasks
                .Where(t => taskIds.Contains(t.Id))
                .ToListAsync();

            context.Tasks.RemoveRange(tasksToDelete);
            await context.SaveChangesAsync();
        }

        public async Task<bool> TitleExistsAsync(string normalizedTitle)
        {
            return await context.Tasks
                .AnyAsync(t => 
                    Regex.Replace(t.Title, @"\s+", " ").Trim().ToLower() == normalizedTitle);
        }
    }
}