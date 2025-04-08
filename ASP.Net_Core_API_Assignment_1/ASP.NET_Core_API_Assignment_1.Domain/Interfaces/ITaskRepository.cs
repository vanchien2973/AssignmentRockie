using ASP.NET_Core_API_Assignment_1.Domain.Entities;

namespace ASP.NET_Core_API_Assignment_1.Domain.Interfaces;

public interface ITaskRepository
{
    Task<TaskItem?> GetByIdAsync(Guid id);
    Task<IEnumerable<TaskItem?>> GetAllAsync();
    Task AddAsync(TaskItem? task);
    Task AddRangeAsync(IEnumerable<TaskItem?> tasks);
    void Update(TaskItem? task);
    void Delete(TaskItem? task);
    Task DeleteRangeAsync(IEnumerable<Guid> taskIds);
    Task<bool> TitleExistsAsync(string normalizedTitle);
}