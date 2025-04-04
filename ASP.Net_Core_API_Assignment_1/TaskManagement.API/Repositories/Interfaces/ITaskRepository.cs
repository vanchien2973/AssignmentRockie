using ASP.Net_Core_API_Assignment_1.Models;

namespace ASP.Net_Core_API_Assignment_1.Repositories.Interfaces;

public interface ITaskRepository
{
    Task<TaskItem> AddTaskAsync(TaskItem task);
    Task<IEnumerable<TaskItem>> GetAllTasksAsync();
    Task<TaskItem?> GetTaskByIdAsync(int id);
    Task DeleteTaskAsync(int id);
    Task<TaskItem?> UpdateTaskAsync(TaskItem task);
    Task AddMultipleTasksAsync(IEnumerable<TaskItem> tasks);
    Task DeleteMultipleTasksAsync(IEnumerable<int> taskIds);
}