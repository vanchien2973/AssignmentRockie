using ASP.Net_Core_API_Assignment_1.DTOs.Task;
using ASP.Net_Core_API_Assignment_1.Models;
using ASP.Net_Core_API_Assignment_1.Repositories.Interfaces;
using ASP.Net_Core_API_Assignment_1.Services.Interfaces;

namespace ASP.Net_Core_API_Assignment_1.Services;

public class TaskService(ITaskRepository taskRepository) : ITaskService
{
    public async Task<TaskItem> CreateTaskAsync(TaskItemDto taskDto)
    {
        var task = new TaskItem
        {
            Title = taskDto.Title,
            IsCompleted = taskDto.IsCompleted
        };
        return await taskRepository.AddTaskAsync(task);
    }

    public async Task<IEnumerable<TaskItem>> GetAllTasksAsync()
    {
        return await taskRepository.GetAllTasksAsync();
    }

    public async Task<TaskItem?> GetTaskByIdAsync(int id)
    {
        return await taskRepository.GetTaskByIdAsync(id);
    }

    public async Task DeleteTaskAsync(int id)
    {
        await taskRepository.DeleteTaskAsync(id);
    }

    public async Task<TaskItem?> UpdateTaskAsync(int id, TaskItemDto taskDto)
    {
        var task = new TaskItem
        {
            Id = id,
            Title = taskDto.Title,
            IsCompleted = taskDto.IsCompleted
        };
        return await taskRepository.UpdateTaskAsync(task);
    }

    public async Task AddMultipleTasksAsync(BulkAddTasksDto bulkAddDto)
    {
        var tasks = bulkAddDto.Tasks.Select(dto => new TaskItem
        {
            Title = dto.Title,
            IsCompleted = dto.IsCompleted
        });
        await taskRepository.AddMultipleTasksAsync(tasks);
    }

    public async Task DeleteMultipleTasksAsync(BulkDeleteTasksDto bulkDeleteDto)
    {
        await taskRepository.DeleteMultipleTasksAsync(bulkDeleteDto.TaskIds);
    }
}