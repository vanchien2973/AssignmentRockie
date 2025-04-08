using ASP.NET_Core_API_Assignment_1.Application.DTOs;
using ASP.NET_Core_API_Assignment_1.Application.DTOs.TaskItem;
using ASP.NET_Core_API_Assignment_1.Application.Interfaces;
using ASP.NET_Core_API_Assignment_1.Domain.Entities;
using ASP.NET_Core_API_Assignment_1.Domain.Interfaces;
using AutoMapper;

namespace ASP.NET_Core_API_Assignment_1.Application.Services;

public class TaskService(ITaskRepository taskRepository, IMapper mapper) : ITaskService
{
    public async Task<TaskItemDto> CreateTaskAsync(CreateTaskItemDto taskItemDto)
    {
        var taskItem = mapper.Map<TaskItem>(taskItemDto);
        taskItem.Id = Guid.NewGuid();
        
        await taskRepository.AddAsync(taskItem);
        return mapper.Map<TaskItemDto>(taskItem);
    }

    public async Task<IEnumerable<TaskItemDto>> GetAllTasksAsync()
    {
        var tasks = await taskRepository.GetAllAsync();
        return mapper.Map<IEnumerable<TaskItemDto>>(tasks);
    }

    public async Task<TaskItemDto> GetTaskByIdAsync(Guid id)
    {
        var task = await taskRepository.GetByIdAsync(id);
        return mapper.Map<TaskItemDto>(task);
    }

    public async Task UpdateTaskAsync(Guid id, UpdateTaskItemDto taskItemDto)
    {
        var existingTask = await taskRepository.GetByIdAsync(id);
        if (existingTask == null)
        {
            throw new KeyNotFoundException($"Task with id {id} not found.");
        }

        mapper.Map(taskItemDto, existingTask);
        taskRepository.Update(existingTask);
    }

    public async Task DeleteTaskAsync(Guid id)
    {
        var task = await taskRepository.GetByIdAsync(id);
        if (task != null)
        {
            taskRepository.Delete(task);
        }
    }

    public async Task BulkAddTasksAsync(BulkTaskItemDto bulkTaskItemDto)
    {
        var tasks = bulkTaskItemDto.Tasks.Select(dto => 
        {
            var task = mapper.Map<TaskItem>(dto);
            task.Id = Guid.NewGuid();
            return task;
        }).ToList();
    
        await taskRepository.AddRangeAsync(tasks);
    }

    public async Task BulkDeleteTasksAsync(BulkDeleteTaskItemDto bulkDeleteTaskItemDto)
    {
        await taskRepository.DeleteRangeAsync(bulkDeleteTaskItemDto.TaskIds);
    }
}