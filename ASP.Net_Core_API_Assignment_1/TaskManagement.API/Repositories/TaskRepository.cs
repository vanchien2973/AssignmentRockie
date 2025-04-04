using ASP.Net_Core_API_Assignment_1.Models;
using ASP.Net_Core_API_Assignment_1.Repositories.Interfaces;

namespace ASP.Net_Core_API_Assignment_1.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly List<TaskItem> _tasks = new();
    private int _nextId = 1;

    public async Task<TaskItem> AddTaskAsync(TaskItem task)
    {
        task.Id = _nextId++;
        _tasks.Add(task);
        return await Task.FromResult(task);
    }

    public async Task<IEnumerable<TaskItem>> GetAllTasksAsync()
    {
        return await Task.FromResult(_tasks.AsEnumerable());
    }

    public async Task<TaskItem?> GetTaskByIdAsync(int id)
    {
        return await Task.FromResult(_tasks.FirstOrDefault(t => t.Id == id));
    }

    public async Task DeleteTaskAsync(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            _tasks.Remove(task);
        }
        await Task.CompletedTask;
    }

    public async Task<TaskItem?> UpdateTaskAsync(TaskItem task)
    {
        var existingTask = _tasks.FirstOrDefault(t => t.Id == task.Id);
        if (existingTask == null) return await Task.FromResult(existingTask);
        existingTask.Title = task.Title;
        existingTask.IsCompleted = task.IsCompleted;
        return await Task.FromResult(existingTask);
    }

    public async Task AddMultipleTasksAsync(IEnumerable<TaskItem> tasks)
    {
        foreach (var task in tasks)
        {
            task.Id = _nextId++;
            _tasks.Add(task);
        }
        await Task.CompletedTask;
    }

    public async Task DeleteMultipleTasksAsync(IEnumerable<int> taskIds)
    {
        var tasksToRemove = _tasks.Where(t => taskIds.Contains(t.Id)).ToList();
        foreach (var task in tasksToRemove)
        {
            _tasks.Remove(task);
        }
        await Task.CompletedTask;
    }
}