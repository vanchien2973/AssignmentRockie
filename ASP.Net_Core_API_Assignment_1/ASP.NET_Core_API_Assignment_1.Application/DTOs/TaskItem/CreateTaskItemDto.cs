namespace ASP.NET_Core_API_Assignment_1.Application.DTOs;

public class CreateTaskItemDto
{
    public string Title { get; set; }
    public bool IsCompleted { get; set; } = false;
}