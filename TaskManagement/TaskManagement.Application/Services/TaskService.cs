using AutoMapper;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Interfaces;
using Task = TaskManagement.Domain.Entities.Task;

namespace TaskManagement.Application.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;

    public TaskService(ITaskRepository taskRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }

    public async Task<TaskDto> CreateTask(CreateTaskDto createTaskDto)
    {
        var task = new Task
        {
            Title = createTaskDto.Title,
            IsCompleted = createTaskDto.IsCompleted,
            CreatedAt = DateTime.UtcNow
        };

        var createdTask = await _taskRepository.AddAsync(task);
        return _mapper.Map<TaskDto>(createdTask);
    }

    public async Task<IEnumerable<TaskDto>> GetAllTasks()
    {
        var tasks = await _taskRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<TaskDto>>(tasks);
    }

    public async Task<TaskDto> GetTaskById(Guid id)
    {
        var task = await _taskRepository.GetByIdAsync(id);
        return _mapper.Map<TaskDto>(task);
    }

    public async Task<TaskDto> UpdateTask(Guid id, UpdateTaskDto updateTaskDto)
    {
        var existingTask = await _taskRepository.GetByIdAsync(id);
        if (existingTask == null)
            throw new KeyNotFoundException("Task not found");

        existingTask.Title = updateTaskDto.Title;
        existingTask.IsCompleted = updateTaskDto.IsCompleted;
        existingTask.UpdatedAt = DateTime.UtcNow;

        await _taskRepository.UpdateAsync(existingTask);
        return _mapper.Map<TaskDto>(existingTask);
    }

    public async Task DeleteTask(Guid id)
    {
        var task = await _taskRepository.GetByIdAsync(id);
        if (task == null)
            throw new KeyNotFoundException("Task not found");

        await _taskRepository.DeleteAsync(task);
    }

    public async Task BulkAddTasks(BulkTaskDto bulkTaskDto)
    {
        var tasks = bulkTaskDto.Tasks.Select(t => new Task
        {
            Title = t.Title,
            IsCompleted = t.IsCompleted,
            CreatedAt = DateTime.UtcNow
        }).ToList();

        await _taskRepository.BulkAddAsync(tasks);
    }

    public async Task BulkDeleteTasks(BulkDeleteDto bulkDeleteDto)
    {
        await _taskRepository.BulkDeleteAsync(bulkDeleteDto.TaskIds);
    }
}