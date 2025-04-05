namespace TaskManagement.Domain.Interfaces;

public interface ITaskRepository
{
    Task<Task> GetByIdAsync(Guid id);
    Task<IEnumerable<Task>> GetAllAsync();
    Task<Task> AddAsync(Task task);
    Task UpdateAsync(Task task);
    Task DeleteAsync(Task task);
    Task BulkAddAsync(IEnumerable<Task> tasks);
    Task BulkDeleteAsync(IEnumerable<Guid> taskIds);
}