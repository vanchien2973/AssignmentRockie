using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Core_API_Assignment_1.Application.DTOs.TaskItem;

public class TaskItemDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
}