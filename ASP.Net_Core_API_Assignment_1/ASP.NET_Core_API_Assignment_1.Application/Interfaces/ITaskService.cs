using ASP.NET_Core_API_Assignment_1.Application.DTOs;

namespace ASP.NET_Core_API_Assignment_1.Application.Interfaces;

public interface ITaskService
{
    Task<TaskItemDto> CreateTaskAsync(CreateTaskItemDto taskItemDto);
    Task<IEnumerable<TaskItemDto>> GetAllTasksAsync();
    Task<TaskItemDto> GetTaskByIdAsync(Guid id);
    Task UpdateTaskAsync(Guid id, UpdateTaskItemDto taskItemDto);
    Task DeleteTaskAsync(Guid id);
    Task BulkAddTasksAsync(BulkTaskItemDto bulkTaskItemDto);
    Task BulkDeleteTasksAsync(BulkDeleteTaskItemDto bulkDeleteTaskItemDto);
}