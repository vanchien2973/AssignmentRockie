using ASP.Net_Core_API_Assignment_1.DTOs.Task;
using ASP.Net_Core_API_Assignment_1.Models;

namespace ASP.Net_Core_API_Assignment_1.Services.Interfaces;

public interface ITaskService
{
    Task<TaskItem> CreateTaskAsync(TaskItemDto taskDto);
    Task<IEnumerable<TaskItem>> GetAllTasksAsync();
    Task<TaskItem?> GetTaskByIdAsync(int id);
    Task DeleteTaskAsync(int id);
    Task<TaskItem?> UpdateTaskAsync(int id, TaskItemDto taskDto);
    Task AddMultipleTasksAsync(BulkAddTasksDto bulkAddDto);
    Task DeleteMultipleTasksAsync(BulkDeleteTasksDto bulkDeleteDto);
}