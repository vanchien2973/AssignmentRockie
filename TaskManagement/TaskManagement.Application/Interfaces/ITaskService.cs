using TaskManagement.Application.DTOs;

namespace TaskManagement.Application.Interfaces;

public interface ITaskService
{
    Task<TaskDto> CreateTask(CreateTaskDto createTaskDto);
    Task<IEnumerable<TaskDto>> GetAllTasks();
    Task<TaskDto> GetTaskById(Guid id);
    Task<TaskDto> UpdateTask(Guid id, UpdateTaskDto updateTaskDto);
    Task DeleteTask(Guid id);
    Task BulkAddTasks(BulkTaskDto bulkTaskDto);
    Task BulkDeleteTasks(BulkDeleteDto bulkDeleteDto);
}